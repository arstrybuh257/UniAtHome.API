using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityRequest;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class UniversityRequestService : IUniversityRequestService
    {
        private readonly IRepository<UniversityCreateRequest> requestsRepository;

        private readonly IEmailService emailService;

        private readonly IUniversityRegistrationService universityRegistrationService;

        private readonly IMapper mapper;

        public UniversityRequestService(
            IRepository<UniversityCreateRequest> requestsRepository,
            IEmailService emailService,
            IUniversityRegistrationService universityRegistrationService,
            IMapper mapper)
        {
            this.requestsRepository = requestsRepository;
            this.emailService = emailService;
            this.universityRegistrationService = universityRegistrationService;
            this.mapper = mapper;
        }

        public async Task AddRequestAsync(UniversityCreateRequestDTO creationInfo)
        {
            UniversityCreateRequest createRequest = mapper.Map<UniversityCreateRequest>(creationInfo);
            createRequest.DateOfCreation = DateTimeOffset.UtcNow;
            await requestsRepository.AddAsync(createRequest);
            await requestsRepository.SaveChangesAsync();
        }

        public async Task ApproveRequestAsync(int id)
        {
            UniversityCreateRequest request = await requestsRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            UniversityCreateRequestViewDTO registerDto = mapper.Map<UniversityCreateRequestViewDTO>(request);
            UniversityCreationResultDTO result = await universityRegistrationService
                .CreateUniversityAsync(registerDto);

            // TODO: load html letter template and fill it in
            await emailService.SendAsync(
                receiver: result.AdminEmail,
                subject: $"{result.UniversityName} registration",
                bodyHtml: "Your university is registered! Use these credentials to sign in to the system:" +
                          $"<br>Email: {result.AdminEmail}<br>Password: {result.AdminPassword}");

            requestsRepository.Remove(request);
            await requestsRepository.SaveChangesAsync();
        }

        public async Task RejectRequestAsync(int id)
        {
            UniversityCreateRequest request = await requestsRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new BadRequestException("Creation request doesn't exist!");
            }

            // TODO: Load email HTML template from file and fill it in
            await emailService.SendAsync(
                request.Email,
                "Your request has been denied",
                $"{request.UniversityName} won't be registered");

            requestsRepository.Remove(request);
            await requestsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UniversityCreateRequestViewDTO>> GetAllRequestsAsync()
        {
            IEnumerable<UniversityCreateRequest> requests = await requestsRepository.Find(_ => true);
            return mapper.Map<IEnumerable<UniversityCreateRequestViewDTO>>(requests);
        }
    }
}

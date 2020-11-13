using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddRequestAsync(UniversityCreateDTO creationInfo)
        {
            var createRequest = new UniversityCreateRequest
            {
                UniversityName = creationInfo.UniversityName,
                SubmitterFirstName = creationInfo.SubmitterFirstName,
                SubmitterLastName = creationInfo.SubmitterLastName,
                Email = creationInfo.Email,
                Comment = creationInfo.Comment,
                Submitted = DateTime.Now
            };
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

            UniversityCreationResultDTO result = await universityRegistrationService
                .CreateUniversityAsync(mapper.Map<UniversityRequestDTO>(request));

            // TODO: load html letter template and fill it in
            await emailService.SendAsync(
                receiver: result.AdminEmail,
                subject: $"{result.UniversityName} registration",
                bodyHtml: "Your university is registered! Use these credentials to sign in to the systen:" +
                          $"<br>Email: {result.AdminEmail}<br>Password: {result.AdminPassword}");

            requestsRepository.Remove(request);
            await requestsRepository.SaveChangesAsync();
        }

        public async Task DeclineRequestAsync(int id)
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

        public async Task<IEnumerable<UniversityRequestDTO>> GetAllRequestsAsync()
        {
            var requests = await requestsRepository.Find(_ => true);
            return requests.Select(r => new UniversityRequestDTO
            {
                Id = r.Id,
                UniversityName = r.UniversityName,
                Email = r.Email,
                Comment = r.Comment,
                SubmitterFirstName = r.SubmitterFirstName,
                SubmitterLastName = r.SubmitterLastName,
                Submitted = r.Submitted,
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityCreation;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class UniversityCreationService : IUniversityCreationService
    {
        private readonly IRepository<UniversityCreateRequest> requestsRepository;

        public UniversityCreationService(IRepository<UniversityCreateRequest> requestsRepository)
        {
            this.requestsRepository = requestsRepository;
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
            // TODO: other actions 

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
            // TODO: other actions like sending "F*ck you via email"

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

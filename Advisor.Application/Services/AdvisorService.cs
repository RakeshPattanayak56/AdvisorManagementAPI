using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Advisor.Application.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _advisorRepository;
        private static readonly Random _random = new Random();

        public AdvisorService(IAdvisorRepository advisorRepository)
        {
            _advisorRepository = advisorRepository;
        }
        public  HealthStatus GenerateHealthStatus()
        {
            int roll = _random.Next(1, 101); // Generate a number between 1 and 100
            if (roll >= 60)  
                return HealthStatus.Green;
            else if (roll < 60 && roll >= 20)
                return HealthStatus.Yellow;
            else 
                return HealthStatus.Red;
        }

        public async Task<Advisors> CreateAdvisorAsync(Advisors advisor)
        {
            advisor.HealthStatus=GenerateHealthStatus();
            // Additional business logic can be added here
            return await _advisorRepository.AddAdvisorAsync(advisor);
        }

        public async Task<Advisors> GetAdvisorByIdAsync(int id)
        {
            return await _advisorRepository.GetAdvisorByIdAsync(id);
        }

        public async Task<IEnumerable<Advisors>> GetAllAdvisorsAsync()
        {
            return await _advisorRepository.GetAllAdvisorsAsync();
        }

        public async Task<Advisors> UpdateAdvisorAsync(Advisors advisor)
        {
            return await _advisorRepository.UpdateAdvisorAsync(advisor);
        }

        public async Task DeleteAdvisorAsync(int id)
        {
            await _advisorRepository.DeleteAdvisorAsync(id);
        }
    }
}

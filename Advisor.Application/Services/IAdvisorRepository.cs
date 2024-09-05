using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Advisor.Application.Services
{
    public interface IAdvisorRepository
    {
        Task<Advisors> AddAdvisorAsync(Advisors advisor);
        Task<Advisors> GetAdvisorByIdAsync(int id);
        Task<IEnumerable<Advisors>> GetAllAdvisorsAsync();
        Task<Advisors> UpdateAdvisorAsync(Advisors advisor);
        Task DeleteAdvisorAsync(int id);
    }
}

using Advisor.Application.Services;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly AdvisorDbContext _context;

        public AdvisorRepository(AdvisorDbContext context)
        {
            _context = context;
        }

        public async Task<Advisors> AddAdvisorAsync(Advisors advisor)
        {
            _context.Advisors.Add(advisor);
            await _context.SaveChangesAsync();
            return advisor;
        }

        public async Task<Advisors> GetAdvisorByIdAsync(int id)
        {
           
            return await _context.Advisors.FindAsync(id);
        }

        public async Task<IEnumerable<Advisors>> GetAllAdvisorsAsync()
        {
            return await _context.Advisors.ToListAsync();
        }

        public async Task<Advisors> UpdateAdvisorAsync(Advisors advisor)
        {
            _context.Advisors.Update(advisor);
            await _context.SaveChangesAsync();
            return advisor;
        }

        public async Task DeleteAdvisorAsync(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor != null)
            {
                _context.Advisors.Remove(advisor);
                await _context.SaveChangesAsync();
            }
        }

    }
}

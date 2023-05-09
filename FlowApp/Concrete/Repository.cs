using System;
using System.Linq;
using System.Threading.Tasks;
using FlowApp.Abstracts;
using FlowApp.Data;
using FlowApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowApp.Concrete
{
	public class Repository : IRepository
    {
        private readonly DataContext _context;

		public Repository(DataContext context)
		{
            _context = context;
		}

        public IQueryable<Candidate> Candidates => _context.Candidates;

        public IQueryable<Condition> Conditions => _context.Conditions;

        public void Add(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
        }

        public void Add(Condition condition)
        {
            _context.Conditions.Add(condition);
        }

        public void Delete(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Deleted;
        }

        public void Delete(Condition condition)
        {
            _context.Entry(condition).State = EntityState.Deleted;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Update(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
        }

        public void Update(Condition condition)
        {
            _context.Entry(condition).State = EntityState.Modified;
        }
    }
}


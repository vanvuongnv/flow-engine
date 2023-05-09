using System;
using System.Linq;
using System.Threading.Tasks;
using FlowApp.Entities;

namespace FlowApp.Abstracts
{
	public interface IRepository
	{
		IQueryable<Candidate> Candidates { get; }
		IQueryable<Condition> Conditions { get; }

		void Add(Candidate candidate);
		void Update(Candidate candidate);
		void Delete(Candidate candidate);

        void Add(Condition candidate);
        void Update(Condition candidate);
        void Delete(Condition candidate);

		Task<bool> SaveChangesAsync();
    }
}


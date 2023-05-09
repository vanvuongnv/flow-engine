using System;
using FlowApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowApp.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Condition> Conditions { get; set; }
	}
}


using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext context;

        public PatientRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Patient patient)
        {
            context.Patitents.Add(patient);
        }

        public async Task<Patient> Get(int id)
        {
            return await context.Patitents.Include(p => p.Image).SingleAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await context.Patitents.Include(p => p.Image).ToListAsync();
        }

        public void Update(Patient patient)
        {
            context.Patitents.Update(patient);
        }
    }
}

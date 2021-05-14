using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistance.Repositories
{
    public class PatientDynamicDataRepository : IPatientDynamicDataRepository
    {
        private List<PatientDynamicData> patientDynamicDatas = new List<PatientDynamicData>();

        private readonly IServiceScopeFactory scopeFactory;

        private readonly ApplicationDbContext context;

        public PatientDynamicDataRepository(IServiceProvider services, IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;

            var scope = scopeFactory.CreateScope();

            context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            List<int> ids = context.Patitents.Select(p => p.Id).ToList();

            foreach(int id in ids) 
            {
                PatientDynamicData patientDynamicData = new PatientDynamicData() { Id = id };

                patientDynamicDatas.Add(patientDynamicData);
            }
        }

        public void Update(int id, PatientDynamicData data)
        {
            PatientDynamicData patientDynamicData = patientDynamicDatas.SingleOrDefault(p => p.Id == id);

            patientDynamicData = data;
        }

        private int cnt = 0;

        public PatientDynamicData Get(int id)
        {
            PatientDynamicData patientDynamicData = patientDynamicDatas.Find(p => p.Id == id);

            patientDynamicData.BloodOxygenLevel++;
            patientDynamicData.Temperature += 2;

            if(cnt == 3)
            {
                patientDynamicData.HeartBeat = 5;
            }
            else
            if(cnt == 4)
            {
                patientDynamicData.HeartBeat = -3;
            }
            else
            if(cnt == 5)
            {
                patientDynamicData.HeartBeat = 3;
            }
            else
            if (cnt == 6)
            {
                patientDynamicData.HeartBeat = 0;

                cnt = -1;
            }

            cnt++;

            return patientDynamicData;
        }
    }
}

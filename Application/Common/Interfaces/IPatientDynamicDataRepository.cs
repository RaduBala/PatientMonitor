using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IPatientDynamicDataRepository
    {
        void Update(int id, PatientDynamicData data);

        PatientDynamicData Get(int id);
    }
}

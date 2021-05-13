using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Patients.Queries.GetDynamicData
{
    public class GetDynamicDataQuery : IRequest<PatientDynamicData>
    {
        public int Id { get; set; }
    }

    public class GetDynamicDataHandler : IRequestHandler<GetDynamicDataQuery, PatientDynamicData>
    {
        private readonly IPatientDynamicDataRepository patientDynamicDataRepository;

        public GetDynamicDataHandler(IPatientDynamicDataRepository patientDynamicDataRepository)
        {
            this.patientDynamicDataRepository = patientDynamicDataRepository;
        }

        public async Task<PatientDynamicData> Handle(GetDynamicDataQuery request, CancellationToken cancellationToken)
        {
            PatientDynamicData patientDynamicData = patientDynamicDataRepository.Get(request.Id);

            return await Task.FromResult(patientDynamicData);
        }
    }
}

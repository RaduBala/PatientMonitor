using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Patients.Queries.GetPatient
{
    public class GetPatientQuery : IRequest<GetPatientDto>
    {
        public int Id { get; set; }
    }

    public class GetPatientHandler : IRequestHandler<GetPatientQuery, GetPatientDto>
    {
        private readonly IPatientRepository patientRepository;

        public GetPatientHandler(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task<GetPatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            Patient patient = await patientRepository.Get(request.Id);
            GetPatientDto getPatientDto = new GetPatientDto 
            {
                Id = patient.Id,
                Name = patient.Name,
                Weight = patient.Weight,
                Height = patient.Height,
                Image = patient.Image.Image,
                Age = patient.Age,
                Address = patient.Address,
            };

            return getPatientDto;
        }
    }
}

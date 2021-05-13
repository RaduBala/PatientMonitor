using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Patients.Queries.GetAllPatients
{
    public class GetAllPatientsQuery : IRequest<IEnumerable<Patient>>
    {
    }

    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<Patient>>
    {
        private readonly IPatientRepository patientRepository;

        public GetAllPatientsHandler(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            return await patientRepository.GetAll();
        }
    }
}

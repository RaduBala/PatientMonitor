using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public string Address { get; set; }
    }

    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, int>
    {
        private readonly IPatientRepository patientRepository;

        private readonly IUnitOfWork unitOfWork;

        public UpdatePatientHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            this.patientRepository = patientRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Patient
            {
                Id = request.Id,
                Name = request.Name,
                Age = request.Age,
                Weight = request.Weight,
                Height = request.Height,
                Address = request.Address,
            };

            patientRepository.Update(entity);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}

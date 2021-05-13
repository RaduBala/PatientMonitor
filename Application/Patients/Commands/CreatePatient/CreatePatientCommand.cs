using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public IFormFile Image { get; set; }
    }

    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPatientRepository patientRepository;

        private readonly IUnitOfWork unitOfWork;

        public CreatePatientHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            this.patientRepository = patientRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var imageStream = new MemoryStream();

            request.Image.CopyTo(imageStream);

            var entity = new Patient 
            {
                Id = request.Id,
                Name = request.Name,
                Weight = request.Weight,
                Height = request.Height,
                Image  = new PatientImage { Image = imageStream.ToArray() },
            };

            patientRepository.Add(entity);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}

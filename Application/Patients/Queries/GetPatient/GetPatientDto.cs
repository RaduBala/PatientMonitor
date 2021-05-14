using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patients.Queries.GetPatient
{
    public class GetPatientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public string Address { get; set; }

        public byte[] Image { get; set; }
    }
}

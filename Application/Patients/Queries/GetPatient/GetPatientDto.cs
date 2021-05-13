using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Patients.Queries.GetPatient
{
    public class GetPatientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public byte[] Image { get; set; }
    }
}

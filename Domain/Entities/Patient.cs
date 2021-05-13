using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public PatientImage Image { get; set; }
    }
}

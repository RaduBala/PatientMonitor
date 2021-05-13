using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PatientImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}

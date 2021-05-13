using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PatientDynamicData
    {
        public int Id { get; set; }

        public int Temperature { get; set; }

        public int BloodOxygenLevel { get; set; }

        public int HeartBeat { get; set; }
    }
}

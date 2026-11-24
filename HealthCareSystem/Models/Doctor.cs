using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Specialization { get; set; } = null!;

        // Many-to-Many with Patient through Appointment
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

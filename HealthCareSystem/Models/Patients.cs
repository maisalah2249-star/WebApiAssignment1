using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCareSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        // Many-to-Many with Doctor through Appointment
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

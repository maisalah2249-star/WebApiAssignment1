using HealthCareSystem;
using HealthCareSystem.Models;
using Microsoft.EntityFrameworkCore;

using var db = new AppDbContext();

if (!db.Patients.Any())
{
    var patient1 = new Patient { Name = "Omar", DateOfBirth = new DateTime(1995, 5, 20) };
    var patient2 = new Patient { Name = "Sara", DateOfBirth = new DateTime(2000, 8, 15) };

    var doctor1 = new Doctor { Name = "Dr. Hassan", Specialization = "Cardiology" };
    var doctor2 = new Doctor { Name = "Dr. Laila", Specialization = "Dermatology" };

    patient1.Appointments.Add(new Appointment { Doctor = doctor1, AppointmentDate = DateTime.Now.AddDays(1) });
    patient1.Appointments.Add(new Appointment { Doctor = doctor2, AppointmentDate = DateTime.Now.AddDays(3) });
    patient2.Appointments.Add(new Appointment { Doctor = doctor1, AppointmentDate = DateTime.Now.AddDays(2) });

    db.Patients.AddRange(patient1, patient2);
    db.SaveChanges();
}

var patients = db.Patients
    .Include(p => p.Appointments).ThenInclude(a => a.Doctor)
    .ToList();

foreach (var p in patients)
{
    Console.WriteLine($"Patient: {p.Name} (born {p.DateOfBirth:d})");
    foreach (var a in p.Appointments)
        Console.WriteLine($"   {a.Doctor.Name} ({a.Doctor.Specialization}) on {a.AppointmentDate:g}");
}
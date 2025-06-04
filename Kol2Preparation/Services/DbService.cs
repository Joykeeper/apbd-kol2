using Kol2Preparation.Data;

namespace Kol2Preparation.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    // For select:
    // var patientData = await _context.Patients
    //     .Where(p => p.IdPatient == patientId)
    //     .Select(p => new PatientDto
    //     {
    //         IdPatient = patient.IdPatient,
    //         FirstName = patient.FirstName,
    //         LastName = patient.LastName,
    //         Birthdate = patient.Birthdate,
    //         Prescriptions = p.Prescriptions
    //             .OrderBy(pr => pr.DueDate)
    //             .Select(pr => new PatientPrescriptionDto
    //             {
    //                 Doctor = new DoctorDto
    //                 {
    //                     IdDoctor = pr.Doctor.IdDoctor,
    //                     FirstName = pr.Doctor.FirstName
    //                 },
    //                 Date = pr.Date,
    //                 DueDate = pr.DueDate,
    //                 Medicaments = pr.PrescriptionMedicaments
    //                     .Select(m => new PatientMedicamentDto
    //                     {
    //                         IdMedicament = m.IdMedicament,
    //                         Name = m.Medicament.Name,
    //                         Dose = m.Dose,
    //                         Description = m.Medicament.Description
    //                     }).ToList()
    //             }).ToList(),
    //     }).FirstAsync();    
    
    // For adding to database:
    // var newPrescription = new Prescription
    // {
    //     IdPatient = prescription.IdPatient,
    //     IdDoctor = prescription.IdDoctor,
    //     Date = prescription.Date,
    //     DueDate = prescription.DueDate,
    //     PrescriptionMedicaments = prescription.Medicaments.Select(m => new PrescriptionMedicament
    //     {
    //         IdMedicament = m.IdMedicament,
    //         Dose = m.Dose,
    //         Details = m.Description
    //     }).ToList()
    // };
    //     
    // await _context.Prescriptions.AddAsync(newPrescription);
    // await _context.SaveChangesAsync();
}
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
    
    // Cheking if something exists, and throwing exception if not
    // var order = await _context.Orders
    //         .FirstOrDefaultAsync(o => o.Id == orderId);
    // if (order is null)
    //          throw new NotFoundException("Order not found.");
    
    // Doing everything under one transaction
    // public async Task FulfillOrder(int orderId, FulfillOrderDto dto)
    // {
    //     using var transaction = await _context.Database.BeginTransactionAsync(); <-- Start transaction
    //
    //     try
    //     {
    //         var order = await _context.Orders
    //             .FirstOrDefaultAsync(o => o.Id == orderId);
    //
    //         if (order is null)
    //             throw new NotFoundException("Order not found.");
    //         
    //         // Doing updates
    //         order.StatusId = status.Id;
    //         order.FulfilledAt = DateTime.Now;
    //         
    //         var relatedProducts = _context.ProductOrders.Where(po => po.OrderId == orderId);
    //         _context.ProductOrders.RemoveRange(relatedProducts);
    //
    //         await _context.SaveChangesAsync(); <-- Save data
    //         await transaction.CommitAsync(); <-- Commit transaction
    //     }
    //     catch (Exception ex)
    //     {
    //         await transaction.RollbackAsync(); <-- Rollback transaction
    //         throw;
    //     }
    // }
}
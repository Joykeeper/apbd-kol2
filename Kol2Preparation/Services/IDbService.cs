using Kol2Preparation.DTOs;

namespace Kol2Preparation.Services;

public interface IDbService
{
    // possible methods
    // Task AddPrescription(PrescriptionDto prescription);
    // Task<PatientDto> GetPatientData(int patientId);
    Task<object> GetCustomerData(int id);
    Task AddCustomerData(DataDto customer);
    Task<Boolean> DoesConcertExist(string concert);
}
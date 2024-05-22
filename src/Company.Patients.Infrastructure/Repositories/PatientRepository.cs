
using Company.Patients.Application.Interfaces;
using Company.Patients.Domain.Entities;

namespace Company.Patients.Infrastructure.Repositories
{
  public class PatientsRepository : MongoDbRepository<PatientEntity>
  {
    public PatientsRepository(IPatientsDbContext dbContext) : base("patients", dbContext)
    {
    }
  }
}

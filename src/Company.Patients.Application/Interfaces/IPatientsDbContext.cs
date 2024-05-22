
namespace Company.Patients.Application.Interfaces
{
  public interface IPatientsDbContext
  {
    T GetSource<T>();
  }
}

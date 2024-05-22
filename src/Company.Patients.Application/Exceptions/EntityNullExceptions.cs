
namespace Company.Patients.Application.Exceptions
{
  public class EntityNullException : Exception
  {
    public EntityNullException(string entityName)
      : base($"Entity{entityName} is null exception")
    {
     
    }
  }
}

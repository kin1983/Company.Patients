
namespace Company.Patients.Application.Exceptions
{
  public class EntityNotFountException:Exception
  {
    public EntityNotFountException(string entityName)
      : base($"Entity{entityName} is null exception")
    {

    }
  }
}

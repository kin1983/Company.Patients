
namespace Company.Patients.Domain.Entities
{
  public class PatientDetailEntity : BaseEntity
  {
    public string Use { get; set; }
    public string Family { get; set; }
    public string[] Given { get; set; }
  }
}

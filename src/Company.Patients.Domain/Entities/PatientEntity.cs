using Company.Patients.Domain.Types;

namespace Company.Patients.Domain.Entities
{
  public class PatientEntity : BaseEntity
  {
    public PatientDetailEntity Name { get; set; }
    public PatientGenderType GenderType { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }

  }
}

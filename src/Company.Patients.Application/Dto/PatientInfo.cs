using Company.Patients.Domain.Types;
using System.ComponentModel.DataAnnotations;


namespace Company.Patients.Application.Dto
{
  public class PatientInfo
  {
    public PatientDetailInfo name { get; set; }
    public PatientGenderType GenderType { get; set; }
    [Required]
    public string birthDate { get; set; }
    public BooleanType active { get; set; }
  }
}

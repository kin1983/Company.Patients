

using Company.Patients.Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace Company.Patients.Application.Dto
{
  public class PatientFullInfo
  {
    public PatientFullDetailInfo name { get; set; }
    public PatientGenderType GenderType { get; set; }
    [Required]
    public string birthDate { get; set; }
    public BooleanType active { get; set; }
  }
}

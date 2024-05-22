
using System.ComponentModel.DataAnnotations;

namespace Company.Patients.Application.Dto
{
  public class PatientDetailInfo
  {
    public string use { get; set; }
    [Required]
    public string family { get; set; }
    public string[] given { get; set; }
  }
}

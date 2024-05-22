
using System.ComponentModel.DataAnnotations;

namespace Company.Patients.Application.Dto
{
  public class PatientFullDetailInfo
  {
    public Guid id { get; set; }
    public string use { get; set; }
    [Required]
    public string family { get; set; }
    public string[] given { get; set; }
  }
}

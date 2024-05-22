

namespace Company.Patients.Application.Commands.Create
{
  public class CreatePatientDetailCommand
  {
    public string Use { get; set; }
    public string Family { get; set; }
    public string[] Given { get; set; }
  }
}

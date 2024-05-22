

namespace Company.Patients.Application.Commands.Update
{
  public class UpdatePatientDetailCommand
  {
    public Guid Id { get; set; }
    public string Use { get; set; }
    public string Family { get; set; }
    public string[] Given { get; set; }
  }
}

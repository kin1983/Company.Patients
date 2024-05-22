

namespace Company.Patient.RequestHelper.Dto
{
  public class ResultInfo<T>
  {
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T Result { get; set; }
  }
}

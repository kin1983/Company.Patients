using Company.Patient.RequestHelper.Dto;
using Company.Patient.RequestHelper.Logic;
using Company.Patients.Application.Dto;
using Company.Patients.Domain.Types;

Console.WriteLine("Создние пациентов");

var url = "http://localhost:4043";
var post = "/api/Patients/Post";

var requestInfo = new RequestInfo()
{
  Uri = $"{url}{post}",
  Name = "POST"

};


var genders = Enum.GetValues(typeof(PatientGenderType));
var families = new[]
{
  new {LastName = "Иванов", FirstName  = "Иван", Surname="Иванович"}, 
  new {LastName = "Петров", FirstName  = "Петр", Surname="Петрович"}, 
  new {LastName = "Сидоров", FirstName  = "Сидр", Surname="Сидорович"}, 
  new {LastName = "Багов", FirstName  = "Павел", Surname="Павлович"}, 
  new {LastName = "Орел", FirstName  = "Андрей", Surname="Викторович"}, 
  new {LastName = "Стапанцов", FirstName  = "Олег", Surname="Олегович"}, 

};


var rnd = new Random();
for (int i = 0; i < 20; i++)
{
  var family = families[rnd.Next(0, families.Length-1)];

  var request = new PatientInfo()
  {
    name = new PatientDetailInfo()
    {
      family = family.LastName,
      given = new[] { family.FirstName, family.Surname },
      use = "official"
    },
    active = rnd.Next(0, 1) == 1 ? BooleanType.True : BooleanType.False,
    GenderType = (PatientGenderType)genders.GetValue(rnd.Next(0, 3)),
    birthDate = new DateTime(
      rnd.Next(1950, 2000),
      rnd.Next(1, 12),
      rnd.Next(1, 12),
      rnd.Next(0, 23),
      rnd.Next(1, 59),
      rnd.Next(1, 59)).ToString()
  };
  var result = CommonSender.Send<PatientInfo, string>(requestInfo, request);
  if (result.IsSuccess)
  {
    Console.WriteLine(result.Result);
  }
  else
  {
    Console.WriteLine($"{result.IsSuccess}:{result.Message}");
  }
}

Console.WriteLine("Создние пациентов завершено");
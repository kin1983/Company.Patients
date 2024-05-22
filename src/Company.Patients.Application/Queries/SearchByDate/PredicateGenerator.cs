
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Company.Patients.Application.Exceptions;
using Company.Patients.Domain.Entities;

namespace Company.Patients.Application.Queries.SearchByDate
{
  public static class PredicateDateGenerator
  {
    public static Expression<Func<PatientEntity, bool>> Create(SearchPatientByDateQuery request)
    {
      var countGroups = 3;
      var pattern = @"([a-z]{2})?(\d{4}-\d{2}-\d{2})";
      var regex = new Regex(pattern);

      if (String.IsNullOrWhiteSpace(request.Date))
      {
        throw new FormatDateException($"Параметр {request.Date} не заполнен");
      }


      if (!regex.IsMatch(request.Date))
      {
        throw new FormatDateException($"Параметр {request.Date} не соотвествует {pattern}");
      }

      var match = regex.Match(request.Date);

      var date = String.Empty;

      if (match.Groups.Count >= countGroups)
      {
        date = match.Groups[2].Value;
      }

      if (!DateTime.TryParse(date, out var dateTime))
      {
        throw new FormatDateException($"Параметр {request.Date} не соотвествует {pattern}");
      }

      var searchParam = match.Groups[1].Value;


      Expression<Func<PatientEntity, bool>> predicate = p => p.BirthDate.Date == dateTime;

      if (!String.IsNullOrWhiteSpace(searchParam))
      {
        if (searchParam.Equals("eq"))
        {
          predicate = p => p.BirthDate.Date == dateTime;
        }
        if (searchParam.Equals("ne"))
        {
          predicate = p => p.BirthDate.Date != dateTime;
        }
      }

      return predicate;
    }
  }
}

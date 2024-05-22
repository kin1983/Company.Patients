using Company.Patient.RequestHelper.Dto;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Company.Patient.RequestHelper.Logic
{
  public static class CommonSender
  {
    public static ResultInfo<TResult> Send<TArguments, TResult>(RequestInfo requestInfo, TArguments arguments)
    {

      try
      {
        var url = requestInfo.Uri;
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = requestInfo.Name;
        request.ContentType = "application/json";

        string json = JsonConvert.SerializeObject(arguments);

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
          streamWriter.Write(json);
        }

        var response = request.GetResponse() as HttpWebResponse;

        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
        {

          var responseItem = ResponseReader.AddResponse<TResult>(response, out var content);
          if (responseItem != null)
          {
            return new ResultInfo<TResult> { IsSuccess = true, Result = responseItem };
          }

          return new ResultInfo<TResult> { Message = content };
        }

        return new ResultInfo<TResult> { Message = "Ошибка получения данных" };
      }
      catch (WebException wex)
      {
       
        if (wex.Response != null)
        {
          var responseStream = wex.Response.GetResponseStream();
          if (responseStream != null)
          {
            using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
            {
              var errorText = streamReader.ReadToEnd();
              return new ResultInfo<TResult> { Message = errorText };
            }
          }
        }


        return new ResultInfo<TResult> { Message = wex.Message };
      }
    }
  }
}

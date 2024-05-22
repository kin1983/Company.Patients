using System.Net;
using System.Runtime.Serialization.Json;


namespace Company.Patient.RequestHelper.Logic
{

  public static class ResponseReader
  {
    #region  Methods

   
    public static T AddResponse<T>(HttpWebResponse webResponse, out string content)
    {
      var responseStream = webResponse.GetResponseStream();
      content = String.Empty;

      if (responseStream != null)
      {
        using (var ms = new MemoryStream())
        {
          responseStream.CopyTo(ms);
          ms.Position = 0;
          var readerResp = new StreamReader(ms);
          content = readerResp.ReadToEnd();
          ms.Position = 0;

          var jsonFormatter = new DataContractJsonSerializer(typeof(T));

          try
          {
            var readObject = (T)jsonFormatter.ReadObject(ms);
            return readObject;
          }
          catch (Exception ex)
          {
            return default;
          }
        }
      }

      content = "Пришел пустой ответ";

      return default;
    }

    #endregion

   
  }
}

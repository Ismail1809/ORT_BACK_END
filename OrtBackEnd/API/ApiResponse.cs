using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace OrtBackEnd.API
{
    public class ApiResponse<T> where T : class
    {
        public int ResultCode { get; set; }
        public string ResultDescription { get; set; }
        public T Payload { get; set; }

        public ApiResponse(int resultCode, string description, T payload = null)
        {
            ResultCode = resultCode;
            ResultDescription = description;
            Payload = payload;
        }
    }


    public static class ResultCode
    {
        public static int Success = 200;

        public static int NotFound = 404;

        public static int NoContent = 204;

        public static int BadRequest = 400;

        public static int ValidationException = 302;
    }

    public static class ResultDescription
    {
        public static string Success = nameof(Success);

        public static string NotFound = nameof(NotFound);

        public static string NoContent = nameof(NoContent);

        public static string BadRequest = nameof(BadRequest);

        public static string ValidationException = nameof(ValidationException);
    }
}
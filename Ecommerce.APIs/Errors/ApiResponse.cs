
namespace Ecommerce.APIs.Errors
{
    public class ApiResponse
    {

        public int StatusCode { get; set; }

        public string? Massage { get; set; }



        public ApiResponse(int statusCode  , string? massage=null)
        {
            StatusCode = statusCode;

            Massage = massage?? GetDefaultMassageForStatuseCode(statusCode);




        }

        private string? GetDefaultMassageForStatuseCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made.",
                401 => "Unauthorized, you are.",
                404 => "Resource found, it was not.",
                500 => "Errors lead to the dark side. Internal server error, it is.",
                _ => null



            };

        }
    }
}

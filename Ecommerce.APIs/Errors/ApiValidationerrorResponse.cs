namespace Ecommerce.APIs.Errors
{
    public class ApiValidationerrorResponse : ApiResponse
    {


        public  IEnumerable<string> Errors { get; set; }

        public ApiValidationerrorResponse(): base(400)
        {
            Errors = new List<string>();
        }

    }
}

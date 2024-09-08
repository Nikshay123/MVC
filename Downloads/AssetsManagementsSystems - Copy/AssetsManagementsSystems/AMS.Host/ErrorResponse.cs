namespace AMS.Host
{
    internal class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
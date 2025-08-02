namespace HMH.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statutCode, string? messsage =null)
        {
            this.statutCode = statutCode;
            Messsage = messsage??GetMessageFromStatusCode(statutCode);
        }

        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "Un Athurized",
                404 => "Resource not Found ",
                500 => "Server Error",
                _ => "Null"
            };
        }

        public int statutCode { get; set; }
        public string? Messsage { get; set; }
    }
}

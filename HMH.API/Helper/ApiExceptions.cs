namespace HMH.API.Helper
{
    public class ApiExceptions : ResponseAPI
    {
        private readonly string detail;

        public ApiExceptions(int statutCode, string? messsage = null , string detail=null) : base(statutCode, messsage)
        {
            this.detail = detail;
        }

    }
}

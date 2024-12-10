namespace PetAdoption.Client.Services
{
    public class CommonService
    {
        public string Token { get; private set; }

        public void SetToken(string token) => Token = token;
    }
}

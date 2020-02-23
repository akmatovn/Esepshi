namespace Esepshi.BLL.Models
{
    public class UserAuthBusinessModel : UsersBusinessModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}

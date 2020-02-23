using System.ComponentModel.DataAnnotations;

namespace Esepshi.DAL.Entities
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

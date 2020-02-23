using System.ComponentModel.DataAnnotations;

namespace Esepshi.Models.Account
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 
        /// </summary>

        [Required]
        public string Password { get; set; }
    }
}

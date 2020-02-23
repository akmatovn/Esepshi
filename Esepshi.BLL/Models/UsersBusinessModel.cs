using System;

namespace Esepshi.BLL.Models
{
    public class UsersBusinessModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// ИИН пользователя
        /// </summary>
        public string Iin { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }
    }
}

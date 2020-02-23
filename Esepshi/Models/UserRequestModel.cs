using Esepshi.BLL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Esepshi.Models
{
    /// <summary>
    /// Модель запроса пользователя
    /// </summary>
    public class UserRequestModel
    {
        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        [DataType(DataType.Date)]
        [RequiredDateTime]
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} обязательное поле для заполнения!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Для поле {0} введите только буквы!")]
        public string FirstName { get; set; }
        /// <summary>
        /// ИИН пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} обязательное поле для заполнения!", AllowEmptyStrings = false)]
        [RegularExpression(@"[0-9]{12}", ErrorMessage = "ИИН должен иметь 12 целочисленных значений!")]
        public string Iin { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Required(ErrorMessage = "{0} обязательное поле для заполнения!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Для поле {0} введите только буквы!")]
        public string LastName { get; set; }

        public UsersBusinessModel ToModel()
        {
            return new UsersBusinessModel
            {
                Iin = Iin,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = (DateTime)BirthDate
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RequiredDateTime : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public RequiredDateTime()
        {
            ErrorMessage = "{0} обязательное поле для заполнения!";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (!(value is DateTime))
                throw new ArgumentException("указан неверный формат даты");

            if ((DateTime)value == DateTime.MinValue)
                return false;

            return true;
        }
    }
}

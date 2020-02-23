using Esepshi.BLL.Models;
using System;

namespace Esepshi.Models
{
    /// <summary>
    /// Модель ответа пользователя
    /// </summary>
    public class UserResponseModel : UserRequestModel
    {
        /// <summary>
        /// Id номер
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserResponseModel() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public UserResponseModel(UsersBusinessModel model)
        {
            Id = model.Id;
            Iin = model.Iin;
            FirstName = model.FirstName;
            LastName = model.LastName;
            BirthDate = model.BirthDate;
        }
        public UsersBusinessModel ToModel()
        {
            return new UsersBusinessModel
            {
                Id = Id,
                Iin = Iin,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = (DateTime)BirthDate
            };
        }
    }
}

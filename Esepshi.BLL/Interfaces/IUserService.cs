using Esepshi.BLL.Models;
using System.Collections.Generic;

namespace Esepshi.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UsersBusinessModel> Users();
        int AddUser(UsersBusinessModel model);
        int UpdateUser(UsersBusinessModel model);
        int DeleteUserByIin(string iin);
        UsersBusinessModel FindByIin(string iin);
    }
}

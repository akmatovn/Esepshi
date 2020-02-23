using ClientAuth.Models;

namespace ClientAuth.Helpers
{
    public static class ExtensionMethods
    {
        public static AccountModel WithoutPassword(this AccountModel user)
        {
            user.Password = null;
            return user;
        }
    }
}

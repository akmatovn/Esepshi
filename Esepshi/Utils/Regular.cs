using System.Text.RegularExpressions;

namespace Esepshi.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Regular
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iin"></param>
        /// <returns></returns>
        public static bool isValid(string iin)
        {
            return Regex.IsMatch(iin, "[0-9]{12}", RegexOptions.IgnoreCase);
        }
    }
}

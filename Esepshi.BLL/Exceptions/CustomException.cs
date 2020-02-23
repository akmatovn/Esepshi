using Microsoft.Data.SqlClient;
using System;

namespace Esepshi.BLL.Exceptions
{
    public class CustomException : Exception
    {
        public int Code { get; set; }

        public CustomException() { }

        public CustomException(int code, string message, Exception innerException)
            : base(message, innerException) { Code = code; }
        public CustomException(int code, string message, SqlException innerException)
            : base(message, innerException) { Code = code; }
    }
}

using Esepshi.DAL.UnitOfWork;
using Microsoft.Data.SqlClient;
using System;

namespace Esepshi.BLL.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        //protected ExecuteResult Execute(Func<ExecuteResult> func, string errorDecription = "")
        //{
        //    try
        //    {
        //        return func();
        //    }
        //    catch (SqlException ex)
        //    {
        //        return ExecuteResult.Error(errorDecription + ex.Message);
        //    }
        //    catch (Exception exp)
        //    {
        //        return ExecuteResult.Error(errorDecription + exp.Message);
        //    }
        //}
    }
}

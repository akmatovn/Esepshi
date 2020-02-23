using Esepshi.DAL.UnitOfWork;

namespace Esepshi.BLL.Services
{
    public class BaseService
    {
        protected IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}

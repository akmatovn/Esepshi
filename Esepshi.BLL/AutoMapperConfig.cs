using AutoMapper;
using Esepshi.BLL.Models;
using Esepshi.DAL.Entities;

namespace Esepshi.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UsersBusinessModel>();
            CreateMap<UsersBusinessModel, Users>();
        }
    }
}

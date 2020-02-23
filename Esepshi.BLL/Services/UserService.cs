using AutoMapper;
using Esepshi.BLL.Exceptions;
using Esepshi.BLL.Interfaces;
using Esepshi.BLL.Models;
using Esepshi.DAL.Entities;
using Esepshi.DAL.GenericRepository;
using Esepshi.DAL.UnitOfWork;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Esepshi.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IGenericRepository<Users> _userRepositoryService;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _userRepositoryService = UnitOfWork.GetRepository<Users>();
            _mapper = mapper;
        }

        public int AddUser(UsersBusinessModel model)
        {
            try
            {
                var into = "Iin, FirstName, LastName, BirthDate";
                var values = "@Iin, @FirstName, @LastName, @BirthDate";
                var res = _userRepositoryService.Add(_mapper.Map<Users>(model), into, values);
                if (res == 1)
                    UnitOfWork.SaveChanges();
                return res;
            }
            catch (SqlException ex)
            {
                throw new CustomException(-5, $"Во время сохранения данных произошла ошибка! Service {nameof(AddUser)}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(-6, $"Во время обработка данных произошла ошибка! Service {nameof(AddUser)}.", ex);
            }
        }

        public int DeleteUserByIin(string iin)
        {
            try
            {
                var res = _userRepositoryService.RemoveByIin(iin);
                if (res == 1)
                    UnitOfWork.SaveChanges();
                return res;
            }
            catch (SqlException ex)
            {
                throw new CustomException(-7, $"Во время удаления данных произошла ошибка! Service { nameof(DeleteUserByIin) }.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(-8, $"Во время обработка данных произошла ошибка! Service {nameof(DeleteUserByIin)}.", ex);
            }
        }

        public UsersBusinessModel FindByIin(string iin)
        {
            try
            {
                var entities = _userRepositoryService.FindByIin(iin);
                return _mapper.Map<UsersBusinessModel>(entities);
            }
            catch (SqlException ex)
            {
                throw new CustomException(-9, $"Во время обращения к базе данных произошла ошибка! Service {nameof(FindByIin)}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(-10, $"Во время обработка данных произошла ошибка! Service {nameof(FindByIin)}.", ex);
            }
        }

        public int UpdateUser(UsersBusinessModel model)
        {
            try
            {
                var set = "Iin = @Iin, FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate";
                var res = _userRepositoryService.Update(_mapper.Map<Users>(model), set);
                if (res == 1)
                    UnitOfWork.SaveChanges();
                return res;
            }
            catch (SqlException ex)
            {
                throw new CustomException(-11, $"Во время обновления данных произошла ошибка! Service {nameof(UpdateUser)}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(-12, $"Во время обработка данных произошла ошибка! Service {nameof(UpdateUser)}.", ex);
            }
        }

        public IEnumerable<UsersBusinessModel> Users()
        {
            try
            {
                var entities = _userRepositoryService.All();
                return _mapper.Map<List<UsersBusinessModel>>(entities);
            }
            catch (SqlException ex)
            {
                throw new CustomException(-13, $"Во время обращения к базе данных произошла ошибка! Service {nameof(Users)}.", ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(-14, $"Во время обработка данных произошла ошибка! Service {nameof(Users)}.", ex);
            }
        }
    }
}

using Esepshi.BLL.Exceptions;
using Esepshi.BLL.Interfaces;
using Esepshi.Models;
using Esepshi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Esepshi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("api/[controller]"), Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Метод для получения все пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        [ProducesResponseType(typeof(BaseResponse<IEnumerable<UserResponseModel>>), 200)]
        [ProducesErrorResponseType(typeof(BaseResponse<string>))]
        public IActionResult GetUsers()
        {
            try
            {
                var result = _userService.Users();
                var data = result.Select(x => new UserResponseModel(x));
                return Ok(new BaseResponse<IEnumerable<UserResponseModel>> { Code = 0, Message = "Ok", Data = data });
            }
            catch (CustomException ex)
            {
                var innerEx = ex.InnerException == null ? "null" : ex.InnerException.Message;
                return BadRequest(new BaseResponse<string> { Code = ex.Code, Message = ex.Message, Data = innerEx });
            }
        }

        /// <summary>
        /// Метод для добавления пользователя
        /// </summary>
        /// <param name="request">Укажите ИИН, имя, фамилию и дату рождения</param>
        /// <returns></returns>
        [HttpPost("Addition")]
        [ProducesResponseType(typeof(BaseResponse<string>), 200)]
        [ProducesErrorResponseType(typeof(BaseResponse<string>))]
        public IActionResult AddUser([FromBody]UserRequestModel request)
        {
            try
            {
                _userService.AddUser(request.ToModel());
                return Ok(new BaseResponse<string> { Code = 0, Message = "Ok", Data = null });
            }
            catch (CustomException ex)
            {
                var innerEx = ex.InnerException == null ? "null" : ex.InnerException.Message;
                return BadRequest(new BaseResponse<string> { Code = ex.Code, Message = ex.Message, Data = innerEx });
            }
        }

        /// <summary>
        /// Метод для редактирования данных пользователя
        /// </summary>
        /// <param name="request">Укажите Id, ИИН, имя, фамилию и дату рождения</param>
        /// <returns></returns>
        [HttpPut("Correction")]
        [ProducesResponseType(typeof(BaseResponse<string>), 200)]
        [ProducesErrorResponseType(typeof(BaseResponse<string>))]
        public IActionResult UpdateUser([FromBody]UserResponseModel request)
        {
            try
            {
                var result = _userService.UpdateUser(request.ToModel());
                if (result == 0)
                    return Ok(new BaseResponse<UserResponseModel> { Code = 0, Message = $"Пользователь с Id: {request.Id} отсутствует!", Data = null });
                return Ok(new BaseResponse<string> { Code = 0, Message = "Ok", Data = null });
            }
            catch (CustomException ex)
            {
                var innerEx = ex.InnerException == null ? "null" : ex.InnerException.Message;
                return BadRequest(new BaseResponse<string> { Code = ex.Code, Message = ex.Message, Data = innerEx });
            }
        }

        /// <summary>
        /// Метод для получения информации о пользователе по ИИН
        /// </summary>
        /// <param name="iin">ИИН пользователя</param>
        /// <returns></returns>
        [HttpGet("Details/{iin?}")]
        [ProducesResponseType(typeof(BaseResponse<UserResponseModel>), 200)]
        [ProducesErrorResponseType(typeof(BaseResponse<string>))]
        public IActionResult FindUser([FromRoute]string iin)
        {
            if (string.IsNullOrWhiteSpace(iin.Trim()) || !Regular.isValid(iin.Trim()))
            {
                return BadRequest(new BaseResponse<string>
                {
                    Code = -3,
                    Message = $"Некорректный ИИН: '{iin}'! " +
                    $"ИИН должен иметь 12 целочисленных значений!",
                    Data = null
                });
            }
            try
            {
                var result = _userService.FindByIin(iin);
                if (result == null)
                    return Ok(new BaseResponse<UserResponseModel> { Code = 0, Message = $"Пользователь с ИИН: '{iin}' отсутствует!", Data = null });
                var data = new UserResponseModel(result);
                return Ok(new BaseResponse<UserResponseModel> { Code = 0, Message = "Ok", Data = data });
            }
            catch (CustomException ex)
            {
                var innerEx = ex.InnerException == null ? "null" : ex.InnerException.Message;
                return BadRequest(new BaseResponse<string> { Code = ex.Code, Message = ex.Message, Data = innerEx });
            }
        }

        /// <summary>
        /// Метод для удаления пользователя по ИИН
        /// </summary>
        /// <param name="iin">ИИН пользователя</param>
        /// <returns></returns>
        [HttpDelete("Removing/{iin?}")]
        [ProducesResponseType(typeof(BaseResponse<string>), 200)]
        [ProducesErrorResponseType(typeof(BaseResponse<string>))]
        public IActionResult DeletUser([FromRoute]string iin)
        {
            if (string.IsNullOrWhiteSpace(iin.Trim()) || !Regular.isValid(iin.Trim()))
            {
                return BadRequest(new BaseResponse<string>
                {
                    Code = -4,
                    Message = $"Некорректный ИИН: '{iin}'! " +
                    $"ИИН должен иметь 12 целочисленных значений!",
                    Data = null
                });
            }
            try
            {
                var result = _userService.DeleteUserByIin(iin);
                if (result == 0)
                    return Ok(new BaseResponse<string> { Code = 0, Message = $"Пользователь с ИИН: '{iin}' отсутствует!", Data = null });
                return Ok(new BaseResponse<string> { Code = 0, Message = $"Пользователь с ИИН: '{iin}' успешно удален.", Data = null });
            }
            catch (CustomException ex)
            {
                var innerEx = ex.InnerException == null ? "null" : ex.InnerException.Message;
                return BadRequest(new BaseResponse<string> { Code = ex.Code, Message = ex.Message, Data = innerEx });
            }
        }
    }
}
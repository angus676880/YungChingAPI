using Microsoft.AspNetCore.Mvc;
using YungChingAPI.Rseponse;

namespace YungChingAPI.Controllers
{
    public class MyBaseController : ControllerBase
    {
        public ActionResult<ApiResponse<T>> Ok<T>(T result)
        {
            var response = new ApiResponse<T>("0000", result);
            return base.Ok(response);
        }

        public ActionResult<ApiResponse<string>> Error(string errorCode, string errorMessage)
        {
            var response = new ApiResponse<string>(errorCode, errorMessage);
            return StatusCode(500, response);
        }
    }
}

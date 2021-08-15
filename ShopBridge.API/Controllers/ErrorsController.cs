using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error-dev")]
        public MyErrorResponse ErrorDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = 500;
            Response.StatusCode = code;
            return new MyErrorResponse(exception);
        }

        [Route("error")]
        public IActionResult ErrorClient()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = 500;
            Response.StatusCode = code;
            return StatusCode(StatusCodes.Status500InternalServerError, exception.InnerException?.Message);
        }
    }
}

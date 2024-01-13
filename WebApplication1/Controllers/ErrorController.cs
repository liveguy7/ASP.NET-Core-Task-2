using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this._logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested cannot be found";
                    _logger.LogWarning($"404 Error. Path = {statusCodeResult.OriginalPath}"
                        + $"and QueryString = {statusCodeResult}");
                    break;

            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error() {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");

            //ViewBag.ExceptionPath = exceptionDetails.Path;
            //ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            //ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;

            return View("Error");

        }

    }
}




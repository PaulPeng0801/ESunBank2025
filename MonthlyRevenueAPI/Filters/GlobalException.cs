using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class GlobalException : IExceptionFilter
{
    private readonly ILogger<GlobalException> _logger;

    public GlobalException(ILogger<GlobalException> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "發生未處理例外");

        context.Result = new ObjectResult(new
        {
            Success = false,
            Message = context.Exception.Message
        })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
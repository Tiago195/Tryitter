// using Microsoft.

public enum teste
{
  ArgumentNullException = 404
}

public class ErrorMiddleware : IMiddleware
{
  private readonly Dictionary<string, int> _errors = new()
  {
    {"System.ArgumentException", 404 }
  };
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (System.Exception e)
    {
      var isMapError = _errors.TryGetValue(e.GetType().ToString(), out int code);
      if (isMapError)
      {
        context.Response.StatusCode = code;
        await context.Response.WriteAsJsonAsync(new { message = e.Message });
      }
      else
      {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { message = "INTERNAL SERVER ERROR" });
      }
    }
  }
}
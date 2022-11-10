
public class ErrorMiddleware : IMiddleware
{
  private readonly Dictionary<string, int> _errors = new()
  {
    {"System.ArgumentException", 409 },
    {"System.ArgumentNullException", 404},
    {"System.InvalidOperationException", 401}
    // {"System.InvalidOperationException", 401}
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
        System.Console.WriteLine(e.Message);
        System.Console.WriteLine(e.GetType());
        context.Response.StatusCode = 500;
        await context.Response.WriteAsJsonAsync(new { message = "INTERNAL SERVER ERROR" });
      }
    }
  }
}
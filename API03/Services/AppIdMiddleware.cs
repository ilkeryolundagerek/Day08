namespace API03.Services
{
    public class AppIdMiddleware
    {
        private readonly RequestDelegate _next;

        public AppIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var app_id_exists = context.Request.Headers.Keys.Contains("app-id");
            if (app_id_exists)
            {
                var app_id = context.Request.Headers["app-id"];
                //app-id nerede kullanılacaksa oraya aktarılır.
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("{\"error\":\"App ID Missing!!!\" }");
                return;
            }


            await _next.Invoke(context);
        }
    }
}

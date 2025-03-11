using System.Globalization;

namespace VeggieVibes.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var cultureHeader = context.Request.Headers["Accept-Language"].ToString();
            var cultureInfo = new CultureInfo("en"); 

            if (!string.IsNullOrWhiteSpace(cultureHeader))
            {
                var culture = cultureHeader.Split(',')
                                           .Select(lang => lang.Split(';').First().Trim()) 
                                           .FirstOrDefault();

                try
                {
                    if (!string.IsNullOrWhiteSpace(culture))
                    {
                        cultureInfo = new CultureInfo(culture);
                    }
                }
                catch (CultureNotFoundException)
                {

                }
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}

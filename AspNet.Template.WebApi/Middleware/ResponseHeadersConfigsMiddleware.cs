using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNet.Template.WebApi.Middleware
{
    public class ResponseHeadersConfigsMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseHeadersConfigsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Remove("X-Powered-By");
            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';base-uri 'self';block-all-mixed-content;font-src 'self' https: data:;frame-ancestors 'self';img-src 'self' data:;object-src 'none';script-src 'self';script-src-attr 'none';style-src 'self' https: 'unsafe-inline';upgrade-insecure-requests");
            context.Response.Headers.Add("X-DNS-Prefetch-Control", "off");
            context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            context.Response.Headers.Add("X-Download-Options", "noopen");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            context.Response.Headers.Add("X-XSS-Protection", "0");
            context.Response.Headers.Add("Date", DateTime.Now.ToString());
            await _next(context);
        }
    }
}
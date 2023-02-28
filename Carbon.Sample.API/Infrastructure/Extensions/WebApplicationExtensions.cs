using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace Carbon.Sample.API.Infrastructure.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomRequestLocalization(this IApplicationBuilder application)
        {
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("tr-TR"),
        };

            application.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }
    }
}

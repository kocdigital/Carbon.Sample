using System.Collections.Generic;
using System.Linq;
using Carbon.Common;
using Carbon.Sample.API.Settings.Constants;
using Carbon.WebApplication.TenantManagementHandler.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carbon.Sample.API.Infrastructure.Filters;
public class BasePropertyBindingActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.ContainsKey("request")) return;

        var request = context.ActionArguments["request"];

        var user = ((ControllerBase)context.Controller).User;

        var tenantId = request?.GetType().GetProperties().FirstOrDefault(x => x.Name == "TenantId");
        if (tenantId == null) return;
        tenantId.SetValue(request, user.GetTenantId());

        var orderables = request?.GetType().GetProperties().FirstOrDefault(x => x.Name == "Orderables");
        if (orderables?.GetValue(request) == null)
        {
            orderables.SetValue(request, new List<Orderable>() { new() { Value = ApplicationConstant.DefaultOrderBy, IsAscending = false } });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
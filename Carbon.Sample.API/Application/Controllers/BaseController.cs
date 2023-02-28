using Carbon.WebApplication;
using Carbon.WebApplication.TenantManagementHandler.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Carbon.Sample.API.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public abstract class BaseController : CarbonTenantManagedController
    {
        protected BaseController(List<ISolutionFilteredService> solutionServices, List<IOwnershipFilteredService> ownershipFilteres)
            : base(solutionServices, ownershipFilteres)
        {

        }
    }
}

using Carbon.Common;
using Carbon.WebApplication.TenantManagementHandler.Dtos;
using Carbon.WebApplication.TenantManagementHandler.Interfaces;
using Carbon.WebApplication;
using System.Collections.Generic;
using Carbon.Sample.API.Settings.Constants;

namespace Carbon.Sample.API.Application.Dto.Base
{
    public abstract class BaseRequestDto<T> : RoleFilteredBaseDto<T>, ISolutionFilteredDto where T : class
    {
        public ICollection<EntitySolutionRelationDto> RelationalOwners { get; set; }
    }
    public class BaseRequestPagedDto<T> : BaseRequestDto<T>, IOrderableDto, IPageableDto where T : class
    {
        public IList<Orderable> Orderables { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public BaseRequestPagedDto()
        {
            PageSize = ApplicationConstant.DefaultIndex;
            PageIndex = ApplicationConstant.DefaultPageSize;
            Orderables = new List<Orderable>() { new Orderable() { Value = ApplicationConstant.DefaultOrderBy, IsAscending = false } };
        }
    }
}

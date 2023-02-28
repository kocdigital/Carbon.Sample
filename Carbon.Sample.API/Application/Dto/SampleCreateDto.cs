using Carbon.Sample.API.Application.Dto.Base;
using System;

namespace Carbon.Sample.API.Application.Dto
{
    public class SampleCreateDto : BaseRequestDto<SampleCreateDto>
    {
        public string Name { get; set; }
    }
}

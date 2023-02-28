namespace Carbon.Sample.API.Infrastructure
{
    public enum ErrorCodes
    {
        //Give a spesific error code for errors
        None = 0,
        NoTenantSpecified = 1,
        PageSizeIsNotInRange = 1011,
        PageIndexIsNotInRange = 1012,
        SampleCreateDtoIsNotValid = 2030,
        SampleDuplicated = 2031,
        SampleDeleteDtoIsNotValid = 2032,
        SampleNotFound = 2033,
        SampleUpdateDtoIsNotValid = 2034,
        DtoCannotBeNull = 2055
    }
}

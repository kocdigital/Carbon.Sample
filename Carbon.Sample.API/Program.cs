using Carbon.Redis;
using Carbon.Sample.API.Infrastructure.Contexts.SampleContext;
using Carbon.WebApplication;
using Carbon.WebApplication.EntityFrameworkCore;
using Carbon.WebApplication.SolutionService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Carbon.Sample.API.Infrastructure;
using Carbon.Sample.API.Infrastructure.Extensions;
using Carbon.HttpClient.Auth;
using Carbon.WebApplication.Middlewares;
using Carbon.WebApplication.SolutionService.Domain;
using Carbon.WebApplication.TenantManagementHandler.Dtos.ErrorHandling;
using Microsoft.Extensions.Configuration;

Console.Title = @"CARBON_SAMPLE_API";
const string cors = "_carbon-sample";
var builder = WebApplication.CreateBuilder(args);

builder.AddCarbonServices((services) =>
{
    services.AddBearerAuthentication(builder.Configuration);
    services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
    // :TODO carbon
    services.AddCustomCors(cors);
    services.AddRedisPersister(builder.Configuration);
    services.AddDatabaseContext<SampleDBContext, Program>(builder.Configuration);
    services.AddApplicationDependencies();
    services.AddHttpClientAuth();
    //Enables Solution based saga events for feature list etc
    services.ConfigureAsSolutionService(builder.Configuration);
    return services;
});
var app = builder.Build();
app.AddCarbonApplication((application) =>
{
    application.UseCors(cors);
    application.UseHsts();
    application.UseHttpsRedirection();
    application.UseCustomRequestLocalization();
    app.CreateAuthentication("RAM");
    app.UseBearerTokenInRequestDto();
    app.MigrateDatabase<SampleDBContext>();

    #region Error Handling Registration

    var errorHandlingConfig = new ErrorHandlingConfig();
    builder.Configuration.GetSection("ErrorHandling").Bind(errorHandlingConfig);
    if (!string.IsNullOrEmpty(errorHandlingConfig.Url))
    {
        app.RegisterApplicationError(application.Environment, errorHandlingConfig);
    }

    #endregion

    #region Solution Migration Registration

    var featuresets = SolutionMigration.GetFeatureSetMigration();
    foreach (var featureset in featuresets)
    {
        app.RegisterAsFeatureSet(new FeatureSetCreationRequest()
            { FeatureSet = featureset, SolutionId = new Guid("D0F8427B-C637-42ED-F4BE-08D7F1B05268") });
    }

    #endregion

    return application;
});
app.Run();
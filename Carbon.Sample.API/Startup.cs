using Carbon.ElasticSearch;
using Carbon.HttpClient.Auth;
using Carbon.MassTransit;
using Carbon.Redis;
using Carbon.Sample.API.Application.Consumers;
using Carbon.Sample.API.Domain.Entities;
using Carbon.Sample.API.Domain.Repositories;
using Carbon.Sample.API.Domain.Repositories.Abstract;
using Carbon.Sample.API.Domain.Services;
using Carbon.Sample.API.Domain.Services.Abstract;
using Carbon.Sample.API.Infrastructure;
using Carbon.Sample.API.Infrastructure.Contexts.SampleContext;
using Carbon.Sample.API.Infrastructure.Contexts.TimeSeriesContexts;
using Carbon.TimeScaleDb.EntityFrameworkCore;
using Carbon.WebApplication;
using Carbon.WebApplication.EntityFrameworkCore;
using Carbon.WebApplication.Middlewares;
using Carbon.WebApplication.SolutionService;
using Carbon.WebApplication.SolutionService.Domain;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Carbon.Sample.API
{
	public class Startup : CarbonStartup<Startup>
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment, false, false)
		{
		}

		public override void CustomConfigureServices(IServiceCollection services)
		{
			services.AddHttpClientAuth();
			services.AddBearerAuthentication(Configuration);
			services.AddTimeScaleDatabaseWithReadOnlyReplicaContext<TimeSerieDataLogContext, TimeSerieDataLogReadOnlyContext, Startup>(Configuration);

			services.AddElasticSearchPersister(Configuration, options =>
			{
				options.SetElasticConfiguration();
				options.Build();
			});

			services.AddRedisPersister(Configuration);

			services.AddDatabaseContext<SampleDBContext, Startup>(Configuration);

			services.AddMassTransitBus(cfg =>
			{
				cfg.AddConsumer<DesiredDataConsumer>();
				cfg.AddRabbitMqBus(Configuration, (provider, busFactoryConfig) =>
				{
					busFactoryConfig.PurgeOnStartup = false;
					busFactoryConfig.ReceiveEndpoint("ExchangeNameForDesiredData", x =>
					{
						x.Consumer<DesiredDataConsumer>(provider);
						x.ClearMessageDeserializers();
						x.UseRawJsonSerializer();
					});
				});
			});

			services.AddScoped<IDataRepository<TimeSerieDataLog>, DataRepository>();
			services.AddScoped<IDataService, DataService>();
			services.AddScoped<ISampleElasticRepository, SampleElasticRepository>();
			services.AddScoped<ISampleRepository, SampleRepository>();
			services.AddScoped<ISampleService, SampleService>();

			//Enables Solution based saga events for feature list etc
			services.ConfigureAsSolutionService(Configuration);

		}

		public override void CustomConfigure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.CreateAuthentication("RAM");
			app.UseBearerTokenInRequestDto();
			app.MigrateDatabase<SampleDBContext>();

			var featuresets = SolutionMigration.GetFeatureSetMigration();
			foreach (var featureset in featuresets)
			{
				app.RegisterAsFeatureSet(new FeatureSetCreationRequest() { FeatureSet = featureset, SolutionId = new Guid("SolutionSpesificGuid") });
			}
		}



	}
}

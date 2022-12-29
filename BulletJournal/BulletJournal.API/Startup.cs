using BulletJournal.API.Converters;
using BulletJournal.Core.Repositories;
using BulletJournal.Core.Services;
using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Factories;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Data.EntityConverters;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.EntityFactories;
using BulletJournal.Data.EntityFactories.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Repositories;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Data.Services;
using BulletJournal.Data.Services.Builders;
using BulletJournal.Data.Services.Factories;
using BulletJournal.Data.Services.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BulletJournal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(jsonOptions =>
            {
                jsonOptions.SerializerSettings.Converters.Add(new BulletJsonConverter());
                jsonOptions.SerializerSettings.Converters.Add(new CollectionJsonConverter());
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                //options.AddSecurityDefinition("Test", )
            });

            services.AddDbContext<BulletJournalContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"))),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            #region Repository

            services.AddTransient<IBulletJournalRepository, BulletJournalRepository>();

            services.AddTransient<IJournalRepository, JournalRepository>();
            services.AddTransient<IIndexRepository, IndexRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();

            #endregion

            #region Services

            services.AddSingleton<ISettingsService, SettingsService>();

            services.AddTransient<IJournalService, JournalService>();
            services.AddTransient<IIndexService, IndexService>();
            services.AddTransient<ITopicService, TopicService>();

            services.AddTransient<IJournalBuilder, JournalBuilder>();
            services.AddTransient<ISpreadBuilder, SpreadBuilder>();
            services.AddTransient<IFutureLogBuilder, FutureLogBuilder>();
            services.AddTransient<IDailyLogBuilder, DailyLogBuilder>();
            services.AddTransient<IMonthlyLogBuilder, MonthlyLogBuilder>();

            services.AddTransient<IJournalManager, JournalManager>();
            services.AddTransient<IPageManager, PageManager>();

            services.AddSingleton<ICollectionFactory, CollectionFactory>();
            services.AddSingleton<ICollectionEntityFactory, CollectionEntityFactory>();

            #endregion

            #region EntityConverters

            services.AddSingleton<IJournalEntityConverter, JournalEntityConverter>();
            services.AddSingleton<IPageEntityConverter, PageEntityConverter>();
            services.AddSingleton<IIndexEntityConverter, IndexEntityConverter>();
            services.AddSingleton<ITopicEntityConverter, TopicEntityConverter>();
            services.AddSingleton<ILogEntityConverter, LogEntityConverter>();

            services.AddSingleton<ICollectionEntityConverter, CollectionEntityConverter>();
            services.AddSingleton<IFutureLogEntityConverter, FutureLogEntityConverter>();
            services.AddSingleton<IDailyLogEntityConverter, DailyLogEntityConverter>();
            services.AddSingleton<IMonthlyLogEntityConverter, MonthlyLogEntityConverter>();

            services.AddSingleton<IBulletEntityConverter, BulletEntityConverter>();
            services.AddSingleton<ITaskEntityConverter, TaskEntityConverter>();
            services.AddSingleton<INoteEntityConverter, NoteEntityConverter>();
            services.AddSingleton<IEventEntityConverter, EventEntityConverter>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

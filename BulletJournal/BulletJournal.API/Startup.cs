using BulletJournal.Core.Repositories;
using BulletJournal.Core.Services;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Repositories;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<BulletJournalContext>();

            #region Repository

            services.AddTransient<IBulletJournalRepository, BulletJournalRepository>();

            services.AddTransient<IJournalRepository, JournalRepository>();
            services.AddTransient<IIndexRepository, IndexRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();

            #endregion

            #region Services

            services.AddTransient<IJournalService, JournalService>();
            services.AddTransient<IIndexService, IndexService>();
            services.AddTransient<ITopicService, TopicService>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

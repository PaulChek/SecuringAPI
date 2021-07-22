using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movie.API.Repos;
using MediatR;

namespace Movie.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            #region MyServices

            services.AddDbContext<Models_Data.MovieDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Sql")));
            services.AddScoped<IMoviesRepo, MovieRepository>();
            services.AddMediatR(typeof(Startup).Assembly);

            //JWT
            services
                .AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", o => {
                        o.Authority = Configuration.GetConnectionString("Auth");
                        o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                            ValidateAudience = false
                        };
                    });

            #endregion


            services.AddControllers();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie.API", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

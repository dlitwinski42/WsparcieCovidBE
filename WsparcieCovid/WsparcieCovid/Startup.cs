using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WsparcieCovid.Data;
using WsparcieCovid.Entities;
using WsparcieCovid.Repositories;
using WsparcieCovid.Services;
using WsparcieCovid.Utils;

namespace WsparcieCovid
{
    public class Startup
    {

        private readonly IConfiguration Configuration;
        private readonly string CorsPolicyName = "WsparcieProject";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            var jwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.AddSingleton(jwtConfig);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
                    ValidAudience = jwtConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContributorRepository, ContributorRepository>();
            services.AddTransient<IEntrepreneurRepository, EntrepreneurRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IJwtManager, JwtManager>();
            services.AddTransient<IDonationRepository, DonationRepository>();
            services.AddTransient<IDonationService, DonationService>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IGiftCardRepository, GiftCardRepository>();
            services.AddTransient<IGiftCardService, GiftCardService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IEntrepreneurService, EntrepreneurService>();
            services.AddTransient<IOrderProductsRepository, OrderProductsRepository>();
            services.AddTransient<ISupportMethodsRepository, SupportMethodsRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Backend", Version = "v1"}); });

            services.AddCors(options =>
                options.AddPolicy(name: CorsPolicyName, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }));
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend v1"));
            }

            app.UseCors(CorsPolicyName);

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}
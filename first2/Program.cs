
using first2.Models;
using first2.Unit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace first2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<BookStoreContext>(op =>
                op.UseLazyLoadingProxies()
                  .UseSqlServer(builder.Configuration.GetConnectionString("bookcon"))
                  .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
            );
            //builder.Services.AddScoped<generalrepo<Book>>();
            //builder.Services.AddScoped<generalrepo<Category>>();
            builder.Services.AddScoped<unitofwork>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BookStoreContext>();
            //---------------------------------------------------------------------------------------------

            builder.Services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                            .AddJwtBearer(
                            //validate token
                op =>
                {
                    op.SaveToken = true;
                    #region secret key
                string key = "welcome to my secret key mohamed elshafie";
                    var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                    #endregion
                    op.TokenValidationParameters = new TokenValidationParameters()
                {
                        IssuerSigningKey = secertkey,
                ValidateIssuer = false,
                ValidateAudience = false
                };
});


            //---------------------------------------------------------------------------------------------

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

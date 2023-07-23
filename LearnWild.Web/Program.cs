using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services;
using LearnWild.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnWild.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ITypeService, TypeService>();
			builder.Services.AddScoped<ICourceService, CourseService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IRegistrationService, RegistrationService>();
			builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
			})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapDefaultControllerRoute();
			app.MapRazorPages();

			app.Run();
		}
	}
}
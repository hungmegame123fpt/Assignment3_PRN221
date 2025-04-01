using BusinessObject.IService;
using BusinessObject.Service;
using DataAccess.Context;
using DataAccess.IRepository;
using DataAccess.Repository;
using eStore.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<FptEStoreDbContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorizationCore();

var conString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FptEStoreDbContext>(options =>
     options.UseSqlServer(conString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = new PathString("/Login");
        options.LogoutPath = new PathString("/Logout");
        options.Cookie.HttpOnly = true;
        options.AccessDeniedPath = new PathString("/Forbidden");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.Events.OnValidatePrincipal = async context =>
        {
            var userPrincipal = context.Principal;
            if (userPrincipal == null || !userPrincipal.Identity.IsAuthenticated)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        };
    });

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductsRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services.AddScoped<FptEStoreDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

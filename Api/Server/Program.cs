using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using oc.TSB.Infrastructure;
using Server.Infrastructure.Middlewares;
using System;
using System.Reflection;

// **************************************************
var webApplicationOptions =
    new Microsoft.AspNetCore.Builder.WebApplicationOptions
    {
        EnvironmentName =
            Microsoft.Extensions.Hosting.Environments.Development,

        //EnvironmentName =
        //    Microsoft.Extensions.Hosting.Environments.Production,
    };

var builder =
    Microsoft.AspNetCore.Builder
    .WebApplication.CreateBuilder(options: webApplicationOptions);
// **************************************************

// **************************************************
// using Microsoft.Extensions.DependencyInjection;
builder.Services
    .AddHttpContextAccessor();
// **************************************************

// **************************************************
builder.Services
    .AddControllers();
// **************************************************

// **************************************************
builder.Services
    .AddRouting(options =>
    {
        options.LowercaseUrls = true;

        // نکته مهم
        // مشکل دارد Captcha Image دستور ذیل با
        //options.LowercaseQueryStrings = true;
    });

// **************************************************

// **************************************************
// اضافه کردن MediatR
builder.Services
    .AddMediatR(Assembly.GetExecutingAssembly());

// **************************************************

// **************************************************

builder.Services
    .AddRazorPages();

// **************************************************

// **************************************************
builder.Services.AddHttpClient();
// **************************************************

// **************************************************

oc.TSB.Gateway.DependencyInjection.ConfigureServices(builder.Configuration, builder.Services);

// **************************************************

// **************************************************

builder.Services
.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QueriesConnectionString"));
});
// **************************************************

// **************************************************

var app = builder.Build();

// **************************************************

// **************************************************

if (app.Environment.IsDevelopment())
{
    // **************************************************
    // using Microsoft.AspNetCore.Builder;
    app.UseDeveloperExceptionPage();
    // **************************************************
}
else
{
    // **************************************************
    // using Infrastructure.Middlewares;
    app.UseGlobalException();
    // **************************************************

    // **************************************************
    // using Microsoft.AspNetCore.Builder;
    //app.UseExceptionHandler
    //	(errorHandlingPath: "/Errors/Error");
    // **************************************************
}
// **************************************************

// **************************************************
// using Microsoft.AspNetCore.Builder;
app.UseHttpsRedirection();

// **************************************************

// **************************************************

app.UseStaticFiles();
// **************************************************

// **************************************************
app.UseRouting();
// **************************************************

// **************************************************
app.MapRazorPages();
// **************************************************

// **************************************************
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Home}/{action=Index}/{id?}");
// **************************************************

// **************************************************

app.Run();

// **************************************************


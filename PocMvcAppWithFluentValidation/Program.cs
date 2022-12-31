using System.Globalization;
using FluentValidation;
using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;
using PocMvcAppWithFluentValidation.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews(config =>
{
    config.Filters.Add<ValidationActionFilter>();
});

if (builder.Environment.IsDevelopment())
    mvcBuilder.AddRazorRuntimeCompilation();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
//builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
//builder.Services.AddFluentValidationAutoValidation();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-GB");

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
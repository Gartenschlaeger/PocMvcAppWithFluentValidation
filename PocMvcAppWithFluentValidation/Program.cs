using System.Globalization;
using FluentValidation;
using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;
using PocMvcAppWithFluentValidation.Filters;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllersWithViews(config =>
{
    config.Filters.Add<ValidationActionFilter>();
});

if (builder.Environment.IsDevelopment())
    mvcBuilder.AddRazorRuntimeCompilation();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-GB");

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
using System.Globalization;
using FluentValidation;
using MediatR;
using PocMvcAppWithFluentValidation.DataAccess;
using PocMvcAppWithFluentValidation.Filters;
using PocMvcAppWithFluentValidation.PipelineBehaviours;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllersWithViews(config =>
{
    // only needed if fluent validation pipeline behavior is not used
    // config.Filters.Add<ValidationActionAsyncFilter>();
});

if (builder.Environment.IsDevelopment())
    mvcBuilder.AddRazorRuntimeCompilation();

// Fluent Validation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-GB");

// MediatR
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

// DataAccess
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
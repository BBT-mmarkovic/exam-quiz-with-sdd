using Microsoft.Extensions.Options;
using Quiz.Web.Models;
using Quiz.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("questionnaire.json", optional: false, reloadOnChange: false);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IValidateOptions<QuestionnaireOptions>, QuestionnaireOptionsValidator>();
builder.Services.AddOptions<QuestionnaireOptions>()
    .Bind(builder.Configuration)
    .ValidateOnStart();
builder.Services.AddSingleton<IQuizService, QuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

public partial class Program { }

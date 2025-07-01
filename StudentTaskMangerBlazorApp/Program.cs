using StudentTaskMangerBlazorApp.Components;
using DAL.Interfaces;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.Services;
using StudentTaskMangerBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ? Register DAL and BLL here BEFORE build
builder.Services.AddScoped<ICourseDAL, CourseDAL>();
builder.Services.AddScoped<ICourseBLL, CourseBLL>();
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<ApiCourseService>();

builder.Services.AddScoped<ITaskDAL, TaskDAL>();
builder.Services.AddScoped<ITaskBLL, TaskBLL>();
builder.Services.AddHttpClient("CourseAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/"); // ? Match your WebAPI port
});


// ? NOW call Build()
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

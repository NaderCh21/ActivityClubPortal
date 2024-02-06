using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ActivityClubPortal.Models;
using Microsoft.EntityFrameworkCore;
using ActivityClubPortal.Repositories;
using ActivityClubPortal.Models.Repositories;
using System.IO;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Activity Club API", Version = "v1" });
});

// Configure database context
builder.Services.AddDbContext<activityclubportalContext>(options =>
    options.UseMySql("server=localhost;database=activityclubportal;user=root;password=root", new MySqlServerVersion(new Version(8, 0, 23))));

// Configure JSON serializer to handle reference loops
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

// Configure repositories
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<GuideRepository>();
builder.Services.AddScoped<LookupRepository>();
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AdminRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Activity Club API V1");
    });
}

app.UseHttpsRedirection();

// Add your API controllers and routes here
app.UseRouting();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "..", "client")),
    RequestPath = "/client"
});

// Configure endpoints
app.UseEndpoints(endpoints =>
{
    // Map controllers
    endpoints.MapControllers();

    // Use the following line to serve the home page on app start
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/client/html/homepage.html");
        return Task.CompletedTask;
    });
});

app.Run();

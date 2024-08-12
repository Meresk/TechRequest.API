using TechRequest.API.Converters;
using TechRequest.API.Converters.RequestConverters;
using TechRequest.API.Dtos.Request;
using TechRequest.API.Dtos.User;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;
using TechRequest.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddScoped<Context>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IConverter<User, ApplicantDto>, UserToApplicantConverter>();
builder.Services.AddScoped<IConverter<User, ExecutorDto>, UserToExecutorConverter>();
builder.Services.AddScoped<IConverter<Request, RequestDto?>, RequestToDtoConverter>();
builder.Services.AddScoped<IConverter<RequestCreationDto, Request?>, CreateDtoToRequestConverter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

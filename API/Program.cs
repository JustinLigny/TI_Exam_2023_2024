using Application.Core.User;
using Application.Features.Invitation;
using Application.Features.Publication;
using Application.Shared.Exceptions.Handler;
using Application.Shared.Mapper;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("BaseExam",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            
            
        });
});

/*  ======================================================
 *  SERVICES
 *  ======================================================
 */
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<PublicationService>();
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();

builder.Services.AddScoped<InvitationService>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();



var app = builder.Build();


app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BaseExam");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
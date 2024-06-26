using AndysManClub.Data;
using AndysManClub.Data.Mapper;
using AndysManClub.Data.Repositories;
using AndysManClub.Domain.Mapper;
using AndysManClub.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting();
builder.Services.AddScoped<IAmcEventRepository, AmcEventRepository>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new PersonMap());
    mc.AddProfile(new AmcEventMap());
    mc.AddProfile(new CreateAmcEvent());
    mc.AddProfile(new ViewAmcEventSummary());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AMCContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("andysmanclub")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AMCContext>()
        .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();


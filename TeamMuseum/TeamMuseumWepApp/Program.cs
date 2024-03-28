using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamMuseum.Domain;
using TeamMuseum.Repository.Data;
using TeamMuseum.Repository.Repositories;
using TeamMuseum.Services.Mapper;
using TeamMuseum.Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TeamMuseumDBContext>(options => {
    // Our DATABASE_URL from js days
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

var x = new MapperConfiguration(cfg => cfg.AddMaps(new[] { "TeamMuseum.Services" }));
builder.Services.AddAutoMapper(typeof(AppointmentMapper));
x.CompileMappings();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<TeamMuseumDBContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketDetailsRepository, TicketDetailsRepository>();
builder.Services.AddScoped<ITicketDetailsService, TicketDetailsService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

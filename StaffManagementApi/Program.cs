using Microsoft.EntityFrameworkCore;
using StaffManagementApi.Data;
using StaffManagementApi.Services;
using StaffManagementApi.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Konfigurasi Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)); // Pastikan sesuai dengan database yang digunakan

// Tambahkan layanan ke container
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddAutoMapper(typeof(StaffMapping));

// Tambahkan layanan otorisasi
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

// Tambahkan controller
builder.Services.AddControllers();

var app = builder.Build();

// Konfigurasi Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();

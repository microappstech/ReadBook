using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Data.Seeder;
using ReadBook.Data.Services;
using ReadBook.Areas.Identity.Data;
using ReadBook.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ReadBookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
},ServiceLifetime.Transient);

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
})
    .AddEntityFrameworkStores<ReadBookContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});


builder.Services.AddAuthorization(op => 
    op.AddPolicy("AdminAccess", policy => 
        policy.RequireClaim("Admin", "Admin")
    )
);



builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddTransient<IWriterService, WriterService>();
builder.Services.AddTransient<IUpload,UploadFile>();



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Writer}/{action=Index}/{id?}");
DbInitializer.Seed(app);
app.MapRazorPages();
app.Run();

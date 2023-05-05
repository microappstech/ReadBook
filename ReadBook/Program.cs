using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadBook.Data;
using ReadBook.Data.IServices;
using ReadBook.Data.Seeder;
using ReadBook.Data.Services;
using ReadBook.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddDbContext<ReadBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ReadBookContext>();
builder.Services.AddAuthorization(op => 
    op.AddPolicy("AdminAccess", policy => 
        policy.RequireClaim("Admin", "Admin")
    )
);



builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IWriterService, WriterService>();
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

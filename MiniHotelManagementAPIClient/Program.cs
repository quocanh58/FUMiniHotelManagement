using BusinessObject.DTO;
using MiniHotelManagementService;
using MiniHotelManagementService.Implements;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddRazorPages(option =>
//{
//    option.Conventions.AddPageRoute("/Index", "");
//}).AddRazorPagesOptions(option =>
//{
//    option.Conventions.AddPageRoute("/Login", "");
//});

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Login", ""));
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:5041",
                                "https://localhost:5024",
                                "https://localhost:7152") // Adjust with your API URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001; // Use the appropriate port where your Razor Pages app is running with HTTPS
});

// add session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
// Use CORS middleware
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapRazorPages();

app.Run();

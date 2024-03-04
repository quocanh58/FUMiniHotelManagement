using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5000",
                            "https://localhost:5041",
                            "https://localhost:5072",
                            "https://localhost:44311") // Adjust with your API URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001; // Use the appropriate port where your Razor Pages app is running with HTTPS
});
builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/CustomerReservation", ""));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();
// Use CORS middleware
app.UseCors("AllowSpecificOrigins");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//});

app.Run();

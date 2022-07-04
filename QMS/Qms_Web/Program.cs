using Microsoft.AspNetCore.Authentication.Cookies;
using QmsCore.Services;

var builder = WebApplication.CreateBuilder(args);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ADD CONTROLLERS WITH VIEWS AND NEWTONSOFT JSON
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

///////////////////////////////////////////////////
// ADD KENDO UI SERVICES TO THE SERVICES CONTAINER
///////////////////////////////////////////////////
builder.Services.AddKendo();
///////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// SET ACCESS TO QMS_APPSETTINGS.JSON WHICH IS USED TO
// 1) INTEGRATE WITH SECUREAUTH
// 2) CONNECT TO DATABASE
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
string logSnippet = "[Qms_Web][Program.cs] =>";
Console.WriteLine($"{logSnippet} (APPSETTINGS_DIRECTORY): '{Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY")}'");
builder.Configuration.SetBasePath(Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY"));
builder.Configuration.AddJsonFile("qms_appsettings.json", optional: false, reloadOnChange: true);
/////////////////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ADD SUPPORT FOR HTTP SESSIONS
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
double sessionTimeoutSeconds = Int32.Parse(builder.Configuration["CookieAuthentication:ExpireMinutes"]) * 60;
builder.Services.AddSession(options =>
{
    options.Cookie.Name = builder.Configuration["SessionCookieName"];
    options.IdleTimeout = TimeSpan.FromSeconds(sessionTimeoutSeconds);
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ADD SUPPORT FOR COOKIE AUTHENTICATION
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/unauthorized";
    });


////////////////////////////////////////////////////////////////////////////////////////// 
// Register UserService
//////////////////////////////////////////////////////////////////////////////////////////          
builder.Services.AddScoped<IUserService, UserService>();
//////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////// 
// Register NotificationService
//////////////////////////////////////////////////////////////////////////////////////////          
//builder.Services.AddScoped<INotificationService, NotificationService>();
//////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////////////// 
// Register EmailService
//////////////////////////////////////////////////////////////////////////////////////////          
//builder.Services.AddScoped<IEmailService, EmailService>();
//////////////////////////////////////////////////////////////////////////////////////////

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

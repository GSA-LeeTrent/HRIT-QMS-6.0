var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());

///////////////////////////////////////////////////
// Add Kendo UI services to the services container
///////////////////////////////////////////////////
builder.Services.AddKendo();
///////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////////////////////////
// Set access to qms_appsettings.json which is need to
// 1) integrate with SecureAuth
// 2) connect to database
/////////////////////////////////////////////////////////////////////////////////////////////////
string logSnippet = "[Qms_Web][Program.cs] =>";
Console.WriteLine($"{logSnippet} (APPSETTINGS_DIRECTORY): '{Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY")}'");
builder.Configuration.SetBasePath(Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY"));
builder.Configuration.AddJsonFile("qms_appsettings.json", optional: false, reloadOnChange: true);
/////////////////////////////////////////////////////////////////////////////////////////////////

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

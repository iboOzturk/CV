using CV_Web.Data;
using CV_Web.Interfaces;
using CV_Web.Repositories;
using Octokit;

var builder = WebApplication.CreateBuilder(args);

var gitHubAccessToken = builder.Configuration["GitHub:AccessToken"];


var gitHubClient = new GitHubClient(new ProductHeaderValue("MyApp"));
gitHubClient.Credentials = new Credentials(gitHubAccessToken);


builder.Services.AddSingleton(gitHubClient);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddHttpClient();


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
	pattern: "{controller=Profile}/{action=Index}/{id?}");

app.Run();

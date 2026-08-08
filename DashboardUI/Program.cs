using Syncfusion.Blazor;
using DashboardUI;
using DashboardUI.Components;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorise(options =>{options.Immediate = true;}).AddBootstrap5Providers().AddFontAwesomeIcons();

builder.Services.AddSingleton(new SqlConnectionString(connectionString)); // simple wrapper, see below

builder.Services.AddScoped<CreateNewUser>();
builder.Services.AddScoped<FaqRepository>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(o => o.DetailedErrors = true);

// Add TabStatus service
builder.Services.AddScoped<TabStatus>();
builder.Services.AddScoped<ToolTabStatus>();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

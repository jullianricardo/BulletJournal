using BulletJournal.Core.Converters;
using BulletJournal.Core.Services;
using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Factories;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Data.EntityConverters;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model.Identity;
using BulletJournal.Data.Services;
using BulletJournal.Data.Services.Builders;
using BulletJournal.Data.Services.Factories;
using BulletJournal.Data.Services.Managers;
using BulletJournal.Web;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BulletJournalContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

    //options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<BulletJournalContext>();

builder.Services.AddHttpClient(Constants.MAIN_HTTP_CLIENT_NAME, client =>
{
    string apiBaseAddress = builder.Configuration.GetValue<string>(Constants.Configuration.API_BASE_ADDRESS);
    client.BaseAddress = new Uri(apiBaseAddress);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromHours(8);
});

builder.Services.AddRazorPages().AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.Converters.Add(new BulletJsonConverter());
    jsonOptions.SerializerSettings.Converters.Add(new CollectionJsonConverter());
    jsonOptions.SerializerSettings.TypeNameHandling = TypeNameHandling.All;
    jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        TypeNameHandling = TypeNameHandling.All,
        Converters = new List<JsonConverter>
        {
            new BulletJsonConverter(),
            new CollectionJsonConverter()
        }
    };
});

builder.Services.AddSingleton<BulletJournal.Web.Services.Interfaces.IJournalService, BulletJournal.Web.Services.JournalService>();
builder.Services.AddSingleton<BulletJournal.Web.Services.Interfaces.IPageService, BulletJournal.Web.Services.PageService>();
builder.Services.AddSingleton<BulletJournal.Web.Services.Interfaces.IBulletService, BulletJournal.Web.Services.BulletService>();
builder.Services.AddSingleton<ISettingsService, SettingsService>();

builder.Services.AddSingleton<IJournalBuilder, JournalBuilder>();
builder.Services.AddSingleton<IPageBuilder, PageBuilder>();
builder.Services.AddSingleton<ISpreadBuilder, SpreadBuilder>();
builder.Services.AddSingleton<IFutureLogBuilder, FutureLogBuilder>();
builder.Services.AddSingleton<IDailyLogBuilder, DailyLogBuilder>();
builder.Services.AddSingleton<IMonthlyLogBuilder, MonthlyLogBuilder>();

builder.Services.AddTransient<IJournalManager, JournalManager>();
builder.Services.AddTransient<IPageManager, PageManager>();

builder.Services.AddSingleton<ICollectionFactory, CollectionFactory>();
builder.Services.AddSingleton<IBulletFactory, BulletFactory>();

builder.Services.AddSingleton<IJournalEntityConverter, JournalEntityConverter>();
builder.Services.AddSingleton<IPageEntityConverter, PageEntityConverter>();
builder.Services.AddSingleton<IIndexEntityConverter, IndexEntityConverter>();
builder.Services.AddSingleton<ITopicEntityConverter, TopicEntityConverter>();
builder.Services.AddSingleton<ILogEntityConverter, LogEntityConverter>();

builder.Services.AddSingleton<ICollectionEntityConverter, CollectionEntityConverter>();
builder.Services.AddSingleton<IFutureLogEntityConverter, FutureLogEntityConverter>();
builder.Services.AddSingleton<IDailyLogEntityConverter, DailyLogEntityConverter>();
builder.Services.AddSingleton<IMonthlyLogEntityConverter, MonthlyLogEntityConverter>();

builder.Services.AddSingleton<IBulletEntityConverter, BulletEntityConverter>();
builder.Services.AddSingleton<ITaskEntityConverter, TaskEntityConverter>();
builder.Services.AddSingleton<INoteEntityConverter, NoteEntityConverter>();
builder.Services.AddSingleton<IEventEntityConverter, EventEntityConverter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();

using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Data.Repositories;
using Library.Infrastructure.Data.Context;
using Library.Application.Services;
using Library.Application.Interfaces.Services;
using Library.Application.Profiles;
using Library.Web.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorService, AuthorService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(BookProfile), typeof(BookViewProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{action=Book}/{id?}",
    defaults: new { controller = "Home" });

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // автоматически создаст/обновит БД
}

app.Run();

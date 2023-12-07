using Microsoft.EntityFrameworkCore;
using MultiGame.Data;
using MultiGame.Services.Comment;
using MultiGame.Services.FavoriteGame;
using MultiGame.Services.Games;
using MultiGame.Services.Player;
using MultiGame.Services.Post;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IFavoriteGameStatsService, FavoriteGameStatsService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

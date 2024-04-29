/*
ПРИМЕР Program.cs С ИСПОЛЬЗОВАНИЕМ Db MySql
*/
using Db.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TournamentManager.Db;

IHost app = new HostBuilder()
    .ConfigureServices(services =>
        services
            .AddTransient<IGameQueries, GameQueries>()
            .AddTransient<IPlayerQueries, PlayerQueries>()
            .AddTransient<ITournamentQueries, TournamentQueries>()
            .AddTransient<IUserQueries, UserQueries>()
            .AddDbContext<TournamentDbContext>(options =>
            {
                options.UseMySQL(/*connectionString*/);
            })
    )
    .Build();

var dbContext = app.Services.GetRequiredService<TournamentDbContext>();
dbContext.Database.Migrate();

var gameQueries = app.Services.GetRequiredService<IGameQueries>();
var playerQueries = app.Services.GetRequiredService<IPlayerQueries>();
var tournamentQueries = app.Services.GetRequiredService<ITournamentQueries>();
var userQueries = app.Services.GetRequiredService<IUserQueries>();

/*
...
*/

await app.RunAsync();
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

using Infrastructure.Factories;
using Infrastructure.Repos;
using Domain.Mappers;
using Domain;

namespace Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                               .AddTransient(x => new LoggerFact().ObtenerLogger(LoggerFact.LoggerType.CONSOLE))
                               .AddTransient<IRepoTasks, RepoTasks>()
                               .AddTransient<IRepoUsers, RepoUsers>()
                               .AddTransient<IRepoResults, RepoResults>()
                               .AddTransient<Mapper>()
                               .AddTransient<TasksManager>()
                               .BuildServiceProvider();

            var procesadorTareas = serviceProvider.GetService<TasksManager>();
            await procesadorTareas.Process();
        }
    }
}

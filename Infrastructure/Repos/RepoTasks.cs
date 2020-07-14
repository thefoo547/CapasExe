using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class RepoTasks : IRepoTasks
    {
        private readonly ILog logger;

        public RepoTasks(ILog logger)
        {
            this.logger = logger;
        }

        public async Task<List<TasksEntity>> GetTasks()
        {
            var client = new HttpClient();
            var urlTareas = "https://jsonplaceholder.typicode.com/todos";
            var respuestaTareas = await client.GetAsync(urlTareas);
            respuestaTareas.EnsureSuccessStatusCode();
            var cuerpoRespuestaTareas = await respuestaTareas.Content.ReadAsStringAsync();
            logger.Log(cuerpoRespuestaTareas);

            var tareas = JsonConvert.DeserializeObject<List<TasksEntity>>(cuerpoRespuestaTareas);
            return tareas;
        }
    }
}

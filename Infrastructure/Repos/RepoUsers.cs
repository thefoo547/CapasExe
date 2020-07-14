using Domain.Interfaces;
using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class RepoUsers : IRepoUsers
    {
        private readonly ILog logger;

        public RepoUsers(ILog logger)
        {
            this.logger = logger;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            var client = new HttpClient();
            var urlUsuarios = "https://jsonplaceholder.typicode.com/users";
            var respuestaUsuarios = await client.GetAsync(urlUsuarios);
            respuestaUsuarios.EnsureSuccessStatusCode();
            var cuerpoRespuestaUsuarios = await respuestaUsuarios.Content.ReadAsStringAsync();
            logger.Log(cuerpoRespuestaUsuarios);
            var usuarios = JsonConvert.DeserializeObject<List<UserEntity>>(cuerpoRespuestaUsuarios);
            return usuarios;
        }
    }
}

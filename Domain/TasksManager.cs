using Domain.Interfaces;
using Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TasksManager
    {
        private readonly ILog logger;
        private readonly IRepoTasks repositorioTareas;
        private readonly IRepoUsers repositorioUsuarios;
        private readonly Mapper mapeador;
        private readonly IRepoResults repositorioResultadoTareasViewModel;

        public TasksManager(ILog logger, IRepoTasks repositorioTareas, IRepoUsers repositorioUsuarios, Mapper mapeador, IRepoResults repositorioResultadoTareasViewModel)
        {
            this.logger = logger;
            this.repositorioTareas = repositorioTareas;
            this.repositorioUsuarios = repositorioUsuarios;
            this.mapeador = mapeador;
            this.repositorioResultadoTareasViewModel = repositorioResultadoTareasViewModel;
        }

        public async Task Process()
        {
            try
            {
                logger.Log("Inicio de procesamiento");

                var tareas = await repositorioTareas.GetTasks();
                var tareasNoRealizadas = tareas.Where(x => !x.Completed).ToList();
                var usuarios = await repositorioUsuarios.GetUsers();

                logger.Log("Inicio transformación a ViewModels");
                var tareasViewModel = mapeador.MapTasks(tareasNoRealizadas, usuarios);

                logger.Log("Inicio escritura de tareas en archivo");
                repositorioResultadoTareasViewModel.Save(tareasViewModel);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
    }
}

using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Repos
{
    public class RepoResults : IRepoResults
    {
        public void Save(List<TaskViewModel> tasks)
        {
            using (StreamWriter writetext = new StreamWriter($@"{Directory.GetCurrentDirectory()}\tareas pendientes.txt", append: true))
            {
                foreach (var tarea in tasks)
                {
                    writetext.WriteLine($"{DateTime.Now.ToString().PadRight(25)}{tarea.Id.ToString().PadRight(10)}{tarea.UserName.PadRight(30)}{tarea.Title}");
                }
            }
        }
    }
}

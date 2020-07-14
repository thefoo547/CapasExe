using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepoTasks
    {
        Task<List<TasksEntity>> GetTasks();
    }
}

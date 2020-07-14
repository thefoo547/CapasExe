using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepoResults
    {
        void Save(List<TaskViewModel> tasks);
    }
}

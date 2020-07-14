using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Mappers
{
    public class Mapper
    {
        public List<TaskViewModel> MapTasks(List<TasksEntity> tasks, List<UserEntity> users)
        {
            var tasksViewModels = new List<TaskViewModel>();
            foreach(var t in tasks)
            {
                var taskViewModel = new TaskViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    UserName = (from user in users where user.Id == t.UserId select user).First().Name.Trim()
                };
                tasksViewModels.Add(taskViewModel);
            }
            return tasksViewModels;
        }
    }
}

using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ITaskDAL
    {
        List<Entities.Models.Task> GetAllTasks();
        Entities.Models.Task GetTaskById(int id);
        void AddTask(Entities.Models.Task task);
        void UpdateTask(Entities.Models.Task task);
        void DeleteTask(int id);
    }
}

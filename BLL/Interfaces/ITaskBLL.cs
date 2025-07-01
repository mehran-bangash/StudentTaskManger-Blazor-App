using System.Collections.Generic;
using TaskEntity = Entities.Models.Task; // ✅ Alias to resolve conflict

namespace BLL.Interfaces
{
    public interface ITaskBLL
    {
        List<TaskEntity> GetAllTasks();
        TaskEntity GetTaskById(int id);
        void AddTask(TaskEntity task);
        void UpdateTask(TaskEntity task);
        void DeleteTask(int id);
    }
}

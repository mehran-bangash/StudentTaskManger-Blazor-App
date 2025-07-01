using BLL.Interfaces;
using DAL.Interfaces;
using TaskEntity = Entities.Models.Task; // ✅ Alias to resolve conflict

namespace BLL.Services
{
    public class TaskBLL : ITaskBLL
    {
        private readonly ITaskDAL _taskDAL;

        public TaskBLL(ITaskDAL taskDAL)
        {
            _taskDAL = taskDAL;
        }

        public List<TaskEntity> GetAllTasks()
        {
            return _taskDAL.GetAllTasks();
        }

        public TaskEntity GetTaskById(int id)
        {
            return _taskDAL.GetTaskById(id);
        }

        public void AddTask(TaskEntity task)
        {
            _taskDAL.AddTask(task);
        }

        public void UpdateTask(TaskEntity task)
        {
            _taskDAL.UpdateTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskDAL.DeleteTask(id);
        }
    }
}

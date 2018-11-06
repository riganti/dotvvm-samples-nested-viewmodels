using DotVVM.Framework.Controls;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
using DotVVM.Samples.NestedViewModel.Services;

namespace DotVVM.Samples.NestedViewModel.ViewModels.Tasks
{
    public class TaskListViewModel : MasterPageViewModel
    {
        private readonly TaskService _taskService;

        public TaskListViewModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        public GridViewDataSet<Task> Tasks { get; set; } = new GridViewDataSet<Task>()
        {
            PagingOptions = { PageSize = DefaultPageSize }
        };

        public override System.Threading.Tasks.Task Init()
        {
            _taskService.LoadTasksDataSet(Tasks);
            return base.Init();
        }

        public void ChangeManager(Task task)
        {
            //todo popup for change user
        }
    }
}
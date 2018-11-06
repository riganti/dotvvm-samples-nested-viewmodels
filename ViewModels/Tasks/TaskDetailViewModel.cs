using DotVVM.Framework.ViewModel;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
using DotVVM.Samples.NestedViewModel.Services;

namespace DotVVM.Samples.NestedViewModel.ViewModels.Tasks
{
    public class TaskDetailViewModel : MasterPageViewModel
    {
        private readonly TaskService _taskService;

        public TaskDetailViewModel(TaskService taskService)
        {
            _taskService = taskService;
        }

        [FromRoute(nameof(Id))] public int Id { get; set; }

        public Task Task { get; set; }

        public override System.Threading.Tasks.Task Load()
        {
            if (!Context.IsPostBack)
            {
                Task = _taskService.GetById(Id);
            }
            return base.Load();
        }
    }
}
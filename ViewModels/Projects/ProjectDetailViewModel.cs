using DotVVM.Framework.ViewModel;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
using DotVVM.Samples.NestedViewModel.Services;
using Task = System.Threading.Tasks.Task;

namespace DotVVM.Samples.NestedViewModel.ViewModels.Projects
{
    public class ProjectDetailViewModel : MasterPageViewModel
    {
        private readonly ProjectService _projectService;

        public ProjectDetailViewModel(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [FromRoute(nameof(Id))] public int Id { get; set; }

        public Project Project { get; set; }

        public override Task Load()
        {
            if (!Context.IsPostBack)
            {
                Project = _projectService.GetById(Id);
            }
            return base.Load();
        }
    }
}
using DotVVM.Framework.Controls;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
using DotVVM.Samples.NestedViewModel.Services;
using Task = System.Threading.Tasks.Task;

namespace DotVVM.Samples.NestedViewModel.ViewModels.Projects
{
    public class ProjectListViewModel : MasterPageViewModel
    {
        private readonly ProjectService _projectService;

        public ProjectListViewModel(ProjectService projectService)
        {
            _projectService = projectService;
        }

        public GridViewDataSet<Project> Projects { get; set; } = new GridViewDataSet<Project>()
        {
            PagingOptions = {PageSize = DefaultPageSize }
        };

        public override Task Init()
        {
            if (Projects.IsRefreshRequired)
            {
                _projectService.LoadUsersDataSet(Projects);
            }

            return base.Init();
        }

        public void ChangeManager(Project project)
        {
            //todo popup for change manager on project
        }
    }
}
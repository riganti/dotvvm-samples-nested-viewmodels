using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using DotVVM.Samples.NestedViewModel.DAL.Entities;
using DotVVM.Samples.NestedViewModel.Services;
using Task = System.Threading.Tasks.Task;

namespace DotVVM.Samples.NestedViewModel.ViewModels.Projects
{
    public class ProjectDetailViewModel : MasterPageViewModel
    {
        private readonly ProjectService _projectService;
        private readonly UsersService _usersService;

        public ProjectDetailViewModel(ProjectService projectService, UsersService usersService)
        {
            _projectService = projectService;
            _usersService = usersService;
        }

        [FromRoute(nameof(Id))] public int Id { get; set; }

        public Project Project { get; set; }

        public bool IsModalVisible { get; set; }
        public GridViewDataSet<User> Users { get; set; }

        public void Save()
        {
            _projectService.Save(Project);
        }
        public override Task Load()
        {
            if (!Context.IsPostBack)
            {
                Project = _projectService.GetById(Id);
            }
            return base.Load();
        }

        public override Task PreRender()
        {
            if (Users?.IsRefreshRequired == true)
            {
                _usersService.LoadUsersDataSet(Users);
            }

            return base.PreRender();
        }

        public void InitModal()
        {
            IsModalVisible = true;
            Users = new GridViewDataSet<User>
            {
                PagingOptions = {PageSize = DefaultPageSize}
            };
            Users.RequestRefresh();
        }

        public void CloseModal()
        {
            IsModalVisible = false;
            Users = default;
        }

        public void AssignManager(User user)
        {
            Project.Manager = user;
            CloseModal();
        }
    }
}
using System.Linq;
using DotVVM.Framework.Controls;
using DotVVM.Samples.NestedViewModel.DAL;
using DotVVM.Samples.NestedViewModel.DAL.Entities;

namespace DotVVM.Samples.NestedViewModel.Services
{
    public class ProjectService : ServiceBase
    {
        public ProjectService(FakeDatabase fakeDatabase)
            : base(fakeDatabase)
        {
        }
        public void LoadUsersDataSet(GridViewDataSet<Project> projects)
        {
            projects.LoadFromQueryable(FakeDatabase.Projects.AsQueryable());
        }

        public Project GetById(int id)
        {
            return FakeDatabase.Projects.FirstOrDefault(p => p.Id == id);
        }
    }
}
using System.Linq;
using DotVVM.Framework.Controls;
using DotVVM.Samples.NestedViewModel.DAL;
using DotVVM.Samples.NestedViewModel.DAL.Entities;

namespace DotVVM.Samples.NestedViewModel.Services
{
    public class TaskService : ServiceBase
    {
        public TaskService(FakeDatabase fakeDatabase)
            : base(fakeDatabase)
        {
        }

        public void LoadTasksDataSet(GridViewDataSet<Task> projects)
        {
            projects.LoadFromQueryable(FakeDatabase.Tasks.AsQueryable());
        }
        public Task GetById(int id)
        {
            return FakeDatabase.Tasks.FirstOrDefault(p => p.Id == id);
        }
    }
}
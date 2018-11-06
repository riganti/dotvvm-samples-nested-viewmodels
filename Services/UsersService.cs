using System.Linq;
using DotVVM.Framework.Controls;
using DotVVM.Samples.NestedViewModel.DAL;
using DotVVM.Samples.NestedViewModel.DAL.Entities;

namespace DotVVM.Samples.NestedViewModel.Services
{
    public class UsersService : ServiceBase
    {
        public UsersService(FakeDatabase fakeDatabase)
            : base(fakeDatabase)
        {
        }
       
        public void LoadUsersDataSet(GridViewDataSet<User> projects)
        {
            projects.LoadFromQueryable(FakeDatabase.Users.AsQueryable());
        }
        public User GetById(int id)
        {
            return FakeDatabase.Users.FirstOrDefault(p => p.Id == id);
        }
    }
}
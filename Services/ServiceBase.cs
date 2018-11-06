using DotVVM.Samples.NestedViewModel.DAL;

namespace DotVVM.Samples.NestedViewModel.Services
{
    public abstract class ServiceBase
    {
        protected readonly FakeDatabase FakeDatabase;

        protected ServiceBase(FakeDatabase fakeDatabase)
        {
            FakeDatabase = fakeDatabase;
        }
    }
}
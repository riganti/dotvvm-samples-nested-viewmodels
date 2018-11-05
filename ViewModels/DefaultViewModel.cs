using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.Samples.NestedViewModel.Models;
using DotVVM.Samples.NestedViewModel.Services;

namespace DotVVM.Samples.NestedViewModel.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public TestViewModel TestViewModel { get;set; }

        public DefaultViewModel(TestViewModel testViewModel)
		{
		    TestViewModel = testViewModel;
		}

        //[Bind(Direction.ServerToClient)]
        //public List<StudentListModel> Students { get; set; }

        //public override async Task PreRender()
        //{
        //    Students =  await studentService.GetAllStudentsAsync();
        //    await base.PreRender();
        //}

        public string Name { get; set; }
        public void ChangeName(string name)
        {
            TestViewModel.Name = name;
        }

    }

    public class TestViewModel:DotvvmViewModelBase
    {
        private readonly StudentService studentService;

        [Bind(Direction.ServerToClient)]
        public List<StudentListModel> Students { get; set; }
        public TestViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public override async Task PreRender()
        {
            Students = await studentService.GetAllStudentsAsync();
            await base.PreRender();
        }

        public string Name { get; set; }
    }
}

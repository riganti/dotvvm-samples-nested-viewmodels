using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Samples.NestedViewModel.Models;
using DotVVM.Samples.NestedViewModel.Services;

namespace DotVVM.Samples.NestedViewModel.ViewModels.CRUD
{
    public class CreateViewModel : MasterPageViewModel
    {
        private readonly StudentService studentService;

        public StudentDetailModel Student { get; set; } = new StudentDetailModel { EnrollmentDate = DateTime.UtcNow.Date };

        public CreateViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }


        public async Task AddStudent()
        {
            await studentService.InsertStudentAsync(Student);
            Context.RedirectToRoute("Default");
        }
    }
}

using System.Collections.Generic;
using Bogus;
using DotVVM.Samples.NestedViewModel.DAL.Entities;

namespace DotVVM.Samples.NestedViewModel.DAL
{
    public class FakeDatabase
    {
        public FakeDatabase()
        {
            Users = new Faker<User>()
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.FirstName, f => f.Person.FirstName)
                .RuleFor(o => o.LastName, f => f.Person.LastName)
                .RuleFor(o => o.Id, f => f.IndexFaker)
                .Generate(20);

            Tasks = new Faker<Task>()
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.Description, f => f.Lorem.Sentences(8, " "))
                .RuleFor(o => o.Manager, f => f.PickRandom(Users))
                .RuleFor(o => o.Resolver, f => f.PickRandom(Users))
                .RuleFor(o => o.Id, f => f.IndexFaker)
                .Generate(20);


            Projects = new Faker<Project>()
                .RuleFor(o => o.Title, f => f.Commerce.Department())
                .RuleFor(o => o.Description, f => f.Lorem.Sentences(8, " "))
                .RuleFor(o => o.Manager, f => f.PickRandom(Users))
                .RuleFor(o => o.Id, f => f.IndexFaker)
                .Generate(20);
        }

        public IEnumerable<Project> Projects { get; }
        public IEnumerable<Task> Tasks { get; }
        public IEnumerable<User> Users { get; }
    }
}
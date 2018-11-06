namespace DotVVM.Samples.NestedViewModel.DAL.Entities
{
    public class Task : IEntity<int>
    {
        public User Manager { get; set; }
        public User Resolver { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
namespace DotVVM.Samples.NestedViewModel.DAL.Entities
{
    public class Project : IEntity<int>
    {
        public User Manager { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
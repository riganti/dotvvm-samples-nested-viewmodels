namespace DotVVM.Samples.NestedViewModel.DAL.Entities
{
    public class User : IEntity<int>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Id { get; set; }
    }
}
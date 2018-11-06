namespace DotVVM.Samples.NestedViewModel.DAL.Entities
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
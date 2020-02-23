namespace Esepshi.DAL.Entities
{
    public class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}

namespace Items.Entities
{
    public class AuditableEntityBase : EntityBase
    {
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public Guid ModifiedById { get; set; }
        public User ModifiedBy { get; set; }
    }
}

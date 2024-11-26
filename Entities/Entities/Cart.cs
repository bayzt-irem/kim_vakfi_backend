namespace Items.Entities
{
    public class Cart : AuditableEntityBase
    {
        public Guid PlaceId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal Yaw { get; set; }
        public decimal Pitch { get; set; }

    }
}

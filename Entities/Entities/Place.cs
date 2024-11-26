namespace Items.Entities
{
    public class Place : AuditableEntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String City { get; set; }
        public String District { get; set; }
        public String ImageUrl { get; set; }
        public List<Cart> Carts { get; set; }

    }
}

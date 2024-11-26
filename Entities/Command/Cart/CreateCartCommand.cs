namespace Items.Command.Cart
{
    public class CreateCartCommand
    {
        public Guid PlaceId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal Yaw { get; set; }
        public decimal Pitch { get; set; }
    }
}

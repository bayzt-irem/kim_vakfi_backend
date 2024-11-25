namespace Items.Command.Cart
{
    public class CreateCartCommand
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal PositionYaw { get; set; }
        public decimal PositionPitch { get; set; }
    }
}

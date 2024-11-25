namespace Items.Dto.Cart
{
    public class CartInfoDto
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal PositionYaw { get; set; }
        public decimal PositionPitch { get; set; }
        public String CreateByUserName { get; set; }
        public String UpdateByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

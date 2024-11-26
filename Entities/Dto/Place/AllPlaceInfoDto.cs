namespace Items.Dto.Place
{
    public class AllPlaceInfoDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String City { get; set; }
        public String District { get; set; }
        public String ImageUrl { get; set; }
        public String CreateByUserName { get; set; }
        public String UpdateByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

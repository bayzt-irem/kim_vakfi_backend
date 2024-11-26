namespace Items.Command.Place
{
    public class UpdatePlaceCommand
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String City { get; set; }
        public String District { get; set; }
    }
}

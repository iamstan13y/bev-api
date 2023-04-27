namespace BevAPI.Models.Data
{
    public class Player
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int KitNumber { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}
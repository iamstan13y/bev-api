namespace BevAPI.Models.Local
{
    public class PlayerRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int KitNumber { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
    }

    public class UpdatePlayerRequest : PlayerRequest
    {
        public int Id { get; set; }
    }
}
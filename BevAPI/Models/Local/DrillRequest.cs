namespace BevAPI.Models.Local
{
    public class DrillRequest
    {
        public string? Type { get; set; }
        public int MaxMark { get; set; }
        public int MinMark { get; set; }
    }

    public class UpdateDrillRequest : DrillRequest
    {
        public int Id { get; set; }
    }
}
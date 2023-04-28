namespace BevAPI.Models.Local
{
    public class PlayerDrillRequest
    {
        public int PlayerId { get; set; }
        public int DrillId { get; set; }
        public int DrillMark { get; set; }
    }

    public class UpdatePlayerDrillRequest : PlayerDrillRequest
    {
        public int Id { get; set; }
    }
}
namespace BevAPI.Models.Data
{
    public class PlayerDrill
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int DrillId { get; set; }
        public int DrillMark { get; set; }
        public Player? Player { get; set; }
        public Drill? Drill { get; set; }
    }
}
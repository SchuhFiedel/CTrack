namespace CTrack.Client.Models
{
    public class ClickTaskParameter
    {
        public List<Guid> IDList { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime Day { get; set; }
    }

    public class ClickEmptyDayParameter
    {
        public DateTime Day { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class DragDropParameter
    {
        public DateTime Day { get; set; }
        public Guid taskID { get; set; }
    }
}

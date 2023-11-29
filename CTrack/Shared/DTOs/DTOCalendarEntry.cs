
using System.ComponentModel;
using System.Drawing;

namespace CTrack.Shared.Models.DTOs
{
    public class DTOCalendarEntry
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; } 
        public string Name { get; set; } = "";
        public Guid? Id { get; set; }
        public string Description { get; set; } = "";
        public FillStyleEnum FillStyle { get; set; }
        public string Color { get; set; }

        public List<DTOTag> TagList;

        private static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }
    }

    public class TaskPosition
    {
        public int Counter { get; set; }
        public bool Top { get; set; }
        public bool Center { get; set; }
        public bool Bottom { get; set; }
    }

    public enum FillStyleEnum
    {
        [Description("fill")]
        Fill = 0,
        [Description("backwardDiagonal")]
        BackwardDiagonal = 1,
        [Description("zigZag")]
        ZigZag = 2,
        [Description("triangles")]
        Triangles = 3,
        [Description("crossDots")]
        CrossDots = 4
    }
}

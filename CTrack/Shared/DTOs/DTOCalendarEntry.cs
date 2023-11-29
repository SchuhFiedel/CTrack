
using System.Drawing;

namespace CTrack.Shared.Models.DTOs
{
    public class DTOCalendarEntry
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = "";
        public Guid? Id { get; set; }
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
}

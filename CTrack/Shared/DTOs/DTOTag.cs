using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTrack.Shared.Models.DTOs
{
    public class DTOTag
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Color BackgroundColor { get; set; } = Color.White;
        public Guid Id { get; set; }
    }
}

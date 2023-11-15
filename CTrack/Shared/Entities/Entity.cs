
using System.ComponentModel.DataAnnotations;

namespace CTrack.Shared.Models.Entities 
{
    public class Entity
    {
        [Key]
        public Guid? Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

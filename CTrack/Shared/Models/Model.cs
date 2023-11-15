
namespace CTrack.Shared.Models.Models
{
    public abstract class Model: ModelOverrides
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}

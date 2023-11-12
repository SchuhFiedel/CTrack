
namespace CTrack.Shared.Models
{
    public abstract class ModelOverrides
    {
        public override string ToString()
        {
        Type type = this.GetType();
        string retval = string.Format("{0} {1}", type.Name, Environment.NewLine);
        foreach (var f in type.GetFields().Where(f => f.IsPublic && !f.IsStatic))
        {
            retval += string.Format("Name: {0}, Value: {1}", f.Name, f.GetValue(this)?.ToString());
        }

        return retval;
        }
    }
}

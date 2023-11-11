using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTrack.Shared.Models
{
    public class Email: ModelOverrides
    {

        static Regex EmailRegex = new(@"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$$");

        public string Value { get; }
        public Email(string value)
        {
            if (!Email.EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("Value must be a valid e-mail!",nameof(Email));
            }
            Value = value.ToLowerInvariant();
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            var other = (Email)obj;
            return Value == other.Value;
        }

        public override int GetHashCode()
            => Value?.GetHashCode() ?? 0;
    }
}

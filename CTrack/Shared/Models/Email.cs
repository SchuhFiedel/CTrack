﻿using System.Text.RegularExpressions;

namespace CTrack.Shared.Models.Models
{
    public class Email: ModelOverrides
    {

        static Regex EmailRegex = new(@"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$$");

        public string Value { get; set; }
        public Email(string value)
        {
            if (!Email.EmailRegex.IsMatch(value))
            {
                throw new ArgumentException("Value must be a valid e-mail!",nameof(Email));
            }
            Value = value.ToLowerInvariant();
        }

        /// <summary>
        /// Dont use -- only for Database Table Creation
        /// </summary>
        public Email()
        {

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

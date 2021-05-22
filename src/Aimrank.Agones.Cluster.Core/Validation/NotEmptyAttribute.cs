using System.Collections;
using System.ComponentModel.DataAnnotations;
using System;

namespace Aimrank.Agones.Cluster.Core.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "\"{0}\" must not be empty.";

        public NotEmptyAttribute() : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return false;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                return !value.Equals(Activator.CreateInstance(type));
            }

            if (value is IEnumerable list)
            {
                return list.GetEnumerator().MoveNext();
            }

            return true;
        }
    }
}
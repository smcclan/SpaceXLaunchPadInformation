using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class LaunchpadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as LaunchpadDto;
            return dto != null &&
                   Id == dto.Id &&
                   Name == dto.Name &&
                   Status == dto.Status;
        }

        public override int GetHashCode()
        {
            var hashCode = 110175493;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}

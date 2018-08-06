using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application
{
    public class LaunchpadFilter
    {
        public IEnumerable<string> LaunchpadIds { get; set; }
        public IEnumerable<string> LaunchpadNames { get; set; }
        public string LaunchpadStatus { get; set; }

        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }

        public LaunchpadFilter()
        {
            this.LaunchpadIds = new List<string>();
            this.LaunchpadNames = new List<string>();
        }

        public bool IsValid()
        {
            var results = new List<ValidationResult>();

            if((this.PageNumber != null && this.PageSize == null) || (this.PageNumber == null && this.PageSize != null))
            {
                return false;
            }

            if(this.PageNumber < 1 || this.PageSize < 1)
            {
                return false;
            }

            if(this.LaunchpadIds.Any() && this.LaunchpadIds.All(x => string.IsNullOrWhiteSpace(x)))
            {
                return false;
            }

            if(this.LaunchpadNames.Any() && this.LaunchpadNames.All(x => string.IsNullOrWhiteSpace(x)))
            {
                return false;
            }

            return true;
        }
    }
}

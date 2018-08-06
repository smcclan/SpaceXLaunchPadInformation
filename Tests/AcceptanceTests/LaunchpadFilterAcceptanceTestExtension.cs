using Application;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace AcceptanceTests
{
    public static class LaunchpadFilterAcceptanceTestExtension
    {
        public static bool HasBeenAppliedTo(this LaunchpadFilter filter, IEnumerable<LaunchpadDto> dtos)
        {
            bool idsValidated = filter.LaunchpadIds.Any() ? dtos.All(x => filter.LaunchpadIds.Contains(x.Id)) : true;

            bool namesValidated = filter.LaunchpadNames.Any() ? dtos.All(x => filter.LaunchpadNames.Contains(x.Name)) : true;

            bool statusValidated = !String.IsNullOrWhiteSpace(filter.LaunchpadStatus) ? dtos.All(x => x.Status.Equals(filter.LaunchpadStatus)) : true;

            bool pageSizeValidated = filter.PageSize != null ? dtos.Count() == filter.PageSize : true;

            return idsValidated && namesValidated && statusValidated && pageSizeValidated;
        }

        public static string ToQueryString(this LaunchpadFilter filter)
        {
            var result = new List<string>();

            result.AddRange(filter.LaunchpadIds.Select(x => $"LaunchpadIds={x}"));
            result.AddRange(filter.LaunchpadNames.Select(x => $"LaunchpadNames={x}"));
            result.Add($"LaunchpadStatus={filter.LaunchpadStatus}");
            result.Add($"PageSize={filter.PageSize}");
            result.Add($"PageNumber={filter.PageNumber}");

            return string.Join("&", result.ToArray());
        }
    }
}

using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public static class LaunchpadListExtensions
    {
        public static IEnumerable<LaunchpadDto> ApplyFilter(this IEnumerable<LaunchpadDto> dtos, LaunchpadFilter filter)
        {
            var filteredDtos = dtos;

            if (filter.LaunchpadIds.Any())
            {
                filteredDtos = filteredDtos.Where(x => filter.LaunchpadIds.Contains(x.Id));
            }

            if (filter.LaunchpadNames.Any())
            {
                filteredDtos = filteredDtos.Where(x => filter.LaunchpadNames.Contains(x.Name));
            }

            if (!String.IsNullOrWhiteSpace(filter.LaunchpadStatus))
            {
                filteredDtos = filteredDtos.Where(x => x.Status.Equals(filter.LaunchpadStatus));
            }

            if(filter.PageSize != null && filter.PageNumber != null)
            {
                var skip = (filter.PageNumber.Value - 1) * filter.PageSize.Value;
                filteredDtos = filteredDtos.Skip(skip).Take(filter.PageSize.Value);
            }

            return filteredDtos;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface ILaunchpadService
    {
        Task<IEnumerable<LaunchpadDto>> FilterLaunchPads(LaunchpadFilter filter);
    }
}

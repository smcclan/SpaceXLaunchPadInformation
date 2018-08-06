using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IHealthCheckService
    {
        Task CheckApplicationHealth();
    }
}

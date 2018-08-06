using Example.LightBDD.NUnit3;
using LightBDD.NUnit3;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

[assembly: ConfiguredLightBddScope]
namespace Example.LightBDD.NUnit3
{
    internal class ConfiguredLightBddScopeAttribute : LightBddScopeAttribute
    {
    }
}
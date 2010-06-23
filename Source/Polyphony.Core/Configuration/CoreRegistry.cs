using StructureMap.Configuration.DSL;

namespace Polyphony.Core.Configuration
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.IncludeNamespaceContainingType<CoreRegistry>();
                         x.ExcludeType<CoreRegistry>();
                         x.LookForRegistries();
                     });
        }
    }
}
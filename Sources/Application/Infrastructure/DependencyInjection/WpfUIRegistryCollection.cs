using System.IO.Abstractions;
using JetBrains.Annotations;
using Lamar;

namespace Mmu.Wb.SqlBuddy.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class WpfUIRegistryCollection : ServiceRegistry
    {
        public WpfUIRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfUIRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}
using System.IO.Abstractions;
using StructureMap;

namespace Mmu.SqlBuddy.WpfUI.Infrastructure.DependencyInjection
{
    public class WpfUIRegistry : Registry
    {
        public WpfUIRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfUIRegistry>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}
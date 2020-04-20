using System.Threading.Tasks;
using Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.Models;

namespace Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.Services
{
    public interface IInsertStatementFactory
    {
        Task<InsertStatements> CreateStatementsAsync(string csvFilePath, string tableIdentifier);
    }
}
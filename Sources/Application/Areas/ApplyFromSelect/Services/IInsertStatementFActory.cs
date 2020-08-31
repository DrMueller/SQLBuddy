using System.Threading.Tasks;
using Mmu.Wb.SqlBuddy.Areas.ApplyFromSelect.Models;

namespace Mmu.Wb.SqlBuddy.Areas.ApplyFromSelect.Services
{
    public interface IInsertStatementFactory
    {
        Task<InsertStatements> CreateStatementsAsync(string csvFilePath, string tableIdentifier);
    }
}
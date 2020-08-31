using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Wb.SqlBuddy.Areas.ApplyFromSelect.Models;

namespace Mmu.Wb.SqlBuddy.Areas.ApplyFromSelect.Services.Implementation
{
    [UsedImplicitly]
    public class InsertStatementFactory : IInsertStatementFactory
    {
        private const string Seperator = ";";
        private readonly IFileSystem _fileSystem;

        public InsertStatementFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<InsertStatements> CreateStatementsAsync(string csvFilePath, string tableIdentifier)
        {
            csvFilePath = csvFilePath.Replace("\"", string.Empty);

            var lines = await _fileSystem.File.ReadAllLinesAsync(csvFilePath);

            var headingLine = lines[0];
            var valueLines = lines.Skip(1).ToList();

            var columns = headingLine.Split(Seperator, StringSplitOptions.RemoveEmptyEntries);
            var rowValues = valueLines
                .Select(val => val.Split(Seperator).ToList())
                .Where(row => row.Count == columns.Length)
                .Select(row => new RowValues(row))
                .ToList();

            var result = new InsertStatements(tableIdentifier, columns, rowValues);

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;

namespace Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.Models
{
    public class InsertStatements
    {
        private readonly IReadOnlyCollection<string> _columnNames;
        private readonly IReadOnlyCollection<RowValues> _rowValues;
        private readonly string _tableIdentifier;

        public InsertStatements(
            string tableIdentifier,
            IReadOnlyCollection<string> columnNames,
            IReadOnlyCollection<RowValues> rowValues)
        {
            _tableIdentifier = tableIdentifier;
            _columnNames = columnNames;
            _rowValues = rowValues;
        }

        public string ToSqlStatements()
        {
            var sb = new StringBuilder();

            foreach (var row in _rowValues)
            {
                sb.Append($"INSERT INTO {_tableIdentifier}");
                sb.Append(" (");
                sb.AppendWithSeperatorExceptLast(_columnNames, ", ");
                sb.Append(") VALUES (");
                row.AppendValuesToSql(sb);
                sb.AppendLine(")");
            }

            return sb.ToString();
        }
    }
}
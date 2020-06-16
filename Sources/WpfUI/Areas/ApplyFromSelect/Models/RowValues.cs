using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.StringBuilders;

namespace Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.Models
{
    public class RowValues
    {
        private readonly IReadOnlyCollection<string> _values;

        public RowValues(IReadOnlyCollection<string> values)
        {
            _values = values;
        }

        internal void AppendValuesToSql(StringBuilder sb)
        {
            var mappedValues = _values.Select(MapValue).ToList();
            sb.AppendWithSeperatorExceptLast(mappedValues, ", ");
        }

        private static string MapValue(string value)
        {
            if (string.IsNullOrEmpty(value) || value.ToUpper() == "NULL")
            {
                return "NULL";
            }

            if (DateTime.TryParse(value, out var dateTime))
            {
                return $"'{dateTime:yyyy-MM-dd HH:mm:ss}'";
            }

            if (!value.Any(char.IsLetter) && !string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            value = value.Replace("'", "''");
            value = $"'{value}'";

            return value;
        }
    }
}
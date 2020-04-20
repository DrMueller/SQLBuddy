using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.Services;

namespace Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.ViewModels.ApplyFromSelect
{
    public class CommandContainer : IViewModelCommandContainer<ApplyFromSelectViewModel>
    {
        private ApplyFromSelectViewModel _context;
        private readonly IInsertStatementFactory _insertStatementFactory;

        public CommandContainer(IInsertStatementFactory insertStatementFactory)
        {
            _insertStatementFactory = insertStatementFactory;
        }

        public CommandsViewData Commands { get; private set; }

        private bool CanCreateInserts
        {
            get => !string.IsNullOrEmpty(_context.TableIdentifier)
                && !string.IsNullOrEmpty(_context.CsvFilePath);
        }

        private ViewModelCommand CreateInserts
        {
            get
            {
                return new ViewModelCommand(
                    "To Insert",
                    new RelayCommand(
                        async () =>
                        {
                            var statement = await _insertStatementFactory.CreateStatementsAsync(_context.CsvFilePath, _context.TableIdentifier);
                            _context.InsertStatement = statement.ToSqlStatements();
                        },
                        () => CanCreateInserts));
            }
        }

        public Task InitializeAsync(ApplyFromSelectViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                CreateInserts);

            return Task.CompletedTask;
        }
    }
}
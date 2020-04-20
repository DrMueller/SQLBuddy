using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.SqlBuddy.WpfUI.Areas.ApplyFromSelect.ViewModels.ApplyFromSelect
{
    public class ApplyFromSelectViewModel : ViewModelBase, INavigatableViewModel, IInitializableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private string _csvFilePath;
        private string _insertStatement;
        private string _tableIdentifier;

        public ApplyFromSelectViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public string CsvFilePath
        {
            get => _csvFilePath;
            set
            {
                if (value == _csvFilePath)
                {
                    return;
                }

                _csvFilePath = value;
                OnPropertyChanged();
            }
        }

        public string HeadingDescription { get; } = "Insert From Select";

        public string InsertStatement
        {
            get => _insertStatement;
            set
            {
                if (value == _insertStatement)
                {
                    return;
                }

                _insertStatement = value;
                OnPropertyChanged();
            }
        }

        public string NavigationDescription { get; } = "S2I";
        public int NavigationSequence { get; } = 1;

        public string TableIdentifier
        {
            get => _tableIdentifier;
            set
            {
                if (value == _tableIdentifier)
                {
                    return;
                }

                _tableIdentifier = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }
    }
}
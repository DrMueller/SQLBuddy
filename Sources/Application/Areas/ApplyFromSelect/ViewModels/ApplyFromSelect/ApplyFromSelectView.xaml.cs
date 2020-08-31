using System.Linq;
using System.Windows;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.SqlBuddy.Areas.ApplyFromSelect.ViewModels.ApplyFromSelect
{
    [UsedImplicitly]
    public partial class ApplyFromSelectView : IViewMap<ApplyFromSelectViewModel>
    {
        public ApplyFromSelectView()
        {
            InitializeComponent();
        }

        private void UserControl_Drop(object sender, System.Windows.DragEventArgs e)
        {
            e.Handled = true;

            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files?.Any() ?? false)
            {
                txb.Text = files.First();
            }
        }

        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
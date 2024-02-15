using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace MyProject
{
    public partial class WelcomeWindow : Window
    {
        public string? SelectedPath { get; set; }

        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = false, 
                InitialDirectory = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Tiedostot"),
                Title = "Valitse tiedosto tai kansio"
            };
            dialog.Filters.Add(new CommonFileDialogFilter("Kaikki tiedostot", "*.*"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SelectedPath = dialog.FileName;
                this.DialogResult = true; 
                this.Close(); 
            }
        }
    }
}

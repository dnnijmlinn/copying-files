using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MyProject;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        WelcomeWindow welcomeWindow = new WelcomeWindow();
        bool? dialogResult = welcomeWindow.ShowDialog();

        if (dialogResult == true)
        {
            string selectedFilePath = welcomeWindow.SelectedPath;

            var folderDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Valitse kansio tiedoston tallentamista varten"
            };

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string selectedFolderPath = folderDialog.FileName;
                string fileName = System.IO.Path.GetFileName(selectedFilePath);
                string destinationFilePath = System.IO.Path.Combine(selectedFolderPath, fileName);

                MessageBoxResult confirmationResult = MessageBox.Show($"Haluatko todella kopioida  \"{fileName}\" tiedoston \"{selectedFolderPath}\"?", "Vahvistus", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (confirmationResult == MessageBoxResult.Yes)
                {
                    var notificationWindow = new NotificationWindow();
                    notificationWindow.Show();

                    try
                    {
                        System.IO.File.Copy(selectedFilePath, destinationFilePath, overwrite: true);
                        notificationWindow.Close(); 
                        MessageBox.Show("Tiedosto kopioitiin onnistuneesti.", "Success");
                    }
                    catch (System.Exception ex)
                    {
                        notificationWindow.Close();
                        MessageBox.Show($"Virhe kopioitaessa tiedostoa: {ex.Message}", "Virhe");
                    }
                }
                else
                {
                    MessageBox.Show("Tiedoston kopiointi peruutettu.", "Peruuta");
                }
            }
        }

        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
    }
}

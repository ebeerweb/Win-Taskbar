using System;
using System.Diagnostics;
using System.Windows;

namespace RegistryToggleApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnableButton_Click(object sender, RoutedEventArgs e)
        {
            ExecutePowerShellScript("enable_taskbar.ps1");
        }

        private void DisableButton_Click(object sender, RoutedEventArgs e)
        {
            ExecutePowerShellScript("disable_taskbar.ps1");
        }

        private void ExecutePowerShellScript(string scriptName)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell";
                psi.Arguments = $"-ExecutionPolicy Bypass -File \"{scriptName}\"";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing PowerShell script: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
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
                string scriptDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts");
                string scriptPath = Path.Combine(scriptDirectory, scriptName);
                
                if (!File.Exists(scriptPath))
                {
                    MessageBox.Show($"Script '{scriptName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell";
                psi.Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"";
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

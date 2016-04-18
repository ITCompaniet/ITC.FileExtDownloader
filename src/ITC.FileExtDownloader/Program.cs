using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ITC.FileExtDownloader
{
    static class Program
    {
        private static readonly string LastPathRegKey = @"Software\ITC.FileExtDownloader\LastDownloadPath";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {
                Application.Run(new SetupForm());
                return;
            }

            var lastPathRegKey = Registry.CurrentUser.CreateSubKey(LastPathRegKey);
            var lastPath = lastPathRegKey?.GetValue("") as string;
            var saveToPath = lastPath;
            var fileSource = new FileInfo(args[0]);

            if (lastPath != null)
            {
                var result = MessageBox.Show($"Download to '{lastPath}'?", @"Downloader", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    saveToPath = null;
            }

            if (saveToPath == null)
            {
                var preSelectedPath = lastPath;

                var tsClientPath = @"\\tsclient\C\";
                if (lastPath == null && Directory.Exists(tsClientPath))
                    preSelectedPath = tsClientPath;

                var browserDialog = new FolderBrowserDialog {SelectedPath = preSelectedPath};
                var result = browserDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                saveToPath = browserDialog.SelectedPath;
            }

            lastPathRegKey.SetValue("", saveToPath);

            var fullSavePath = Path.Combine(saveToPath, fileSource.Name);
            try
            {
                File.Copy(fileSource.FullName, fullSavePath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Could not copy file to {fullSavePath}: {e.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

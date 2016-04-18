using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ITC.FileExtDownloader
{
    public partial class SetupForm : Form
    {
        public static string ProgramId => "ITC.FileExtDownloader";
        
        public SetupForm()
        {
            InitializeComponent();
            SetupProgramClassesRoot();
            LoadListWithExts();
        }

        private void LoadListWithExts()
        {
            listBoxExts.Items.Clear();
            
            var extensions = Registry.ClassesRoot.GetSubKeyNames()
                .Where(s => s.StartsWith("."));

            foreach (var extension in from extension in extensions
                                      let extSubKey = Registry.ClassesRoot.OpenSubKey(extension, false)
                                      let bindedProgram = extSubKey.GetValue("", false).ToString()
                                      where bindedProgram == ProgramId
                                      select extension)
            {
                listBoxExts.Items.Add(extension);
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNewExt.Text.Length < 3 && textBoxNewExt.Text.Substring(0) != ".")
                return;
            
            Associate(textBoxNewExt.Text);
            textBoxNewExt.Text = "";
            LoadListWithExts();
        }

        public static void SetupProgramClassesRoot()
        {
            using (var key = Registry.ClassesRoot.CreateSubKey(ProgramId))
            {
                var application = new FileInfo(Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", ""));

                key.SetValue("", "ITC FileExtDownloader");
                var icoPath = Path.Combine(application.DirectoryName, "download.ico");
                key.CreateSubKey("DefaultIcon").SetValue("", icoPath);
                
                key.CreateSubKey(@"Shell\Open\Command").SetValue("", application.FullName + " \"%1\"");
            }
        }

        public static void Associate(string extension)
        {
            Registry.ClassesRoot.CreateSubKey(extension)?.SetValue("", ProgramId);
        }
    }
}

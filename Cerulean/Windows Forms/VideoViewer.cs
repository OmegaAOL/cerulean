using System;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace Cerulean
{
    public partial class VideoViewer : Form
    {
        private VlcControl vlcControl;
        private string url;

        public VideoViewer(string urltemp)
        {
            url = urltemp;
            this.Height = Screen.GetWorkingArea(this).Height;
            this.Width = Screen.GetWorkingArea(this).Width;
            CenterToScreen();

            vlcControl = new VlcControl();
            vlcControl.BeginInit();
            vlcControl.Dock = DockStyle.Fill;
            this.Controls.Add(vlcControl);

            var vlcLibDir = new DirectoryInfo(Path.Combine(Application.StartupPath, "libvlc"));
            vlcControl.VlcLibDirectory = vlcLibDir;     

            vlcControl.EndInit();
            this.Load += VideoViewer_Load;
        }

        private void VideoViewer_Load(object sender, EventArgs e)
        {
            vlcControl.Play(url);
        }
    }
}

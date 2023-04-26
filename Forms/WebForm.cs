using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using static System.Windows.Forms.DataFormats;

namespace FinalProjectSVGEditor
{
    public partial class WebForm : Form
    {


        public WebForm()
        {
            InitializeComponent();
            webView21.CreationProperties = new CoreWebView2CreationProperties()
            {
                UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp"),
            };
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            webView21.EnsureCoreWebView2Async();
        }

        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                string fullPath = Path.Combine(Application.StartupPath, "SVGTempOutput.svg");
                webView21.CoreWebView2.Navigate($"file:///{fullPath}");
            }
        }

        private void WebForm_VisibleChanged(object sender, EventArgs e)
        {
            this.webView21.Reload();
        }
    }
}

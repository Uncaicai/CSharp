using SimpleCrawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CrawlerForm
{
    public partial class Form1 : Form
    {

        private Crawler crawler;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void AddUrl(string url)
        {
            lbxFinish.Items.Add(url);
        }
        private void Crawler_PageDownloaded(string url)
        {
            if (this.lbxFinish.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { url });
            }
            else
            {
                AddUrl(url);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            lbxFinish.Items.Clear();
            crawler = new Crawler(textBox_url.Text);
            crawler.PageDownloaded += Crawler_PageDownloaded;
            new Thread(crawler.Crawl).Start();
        }
    }
}

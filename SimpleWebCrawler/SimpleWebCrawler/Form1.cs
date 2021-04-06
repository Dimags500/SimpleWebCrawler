using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace SimpleWebCrawler
{
    public partial class SimpleWebCrawler : Form
    {

        static TimeSpan totalTime;
        public SimpleWebCrawler()
        {
            InitializeComponent();

        }

        private void SyncDownload(string [] arr)
        {
            // function that downloading webSites Synchronic way 

            WebClient client = new WebClient();
            Stopwatch stopWatch = new Stopwatch();


            if (Check(arr) == true)
            {
                text_output.AppendText("\n" + "We Started ! ");

                foreach (var item in arr)
                {
                    stopWatch.Start();
                    client.DownloadString(item);
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;
                    Display(item, ts);
                }

                Display("Total Run Time ", totalTime);
            }

        }

        private void Display(string item , TimeSpan ts )
        {
            // display function 

             totalTime  +=  ts ; 

            item += "--------------------------------";
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                         ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            text_output.AppendText("\n" + elapsedTime + " - " + item.TrimStart().Substring(0, 40));


        }

        private bool Check(string[] arr)
        {
            // checking input for null or not typed feilds 

            if (arr != null)
            {
                foreach (var item in arr)
                {
                    item.TrimStart();

                    if (item == null || item.Equals(""))
                    {
                        text_output.AppendText("\n" + "Error - All fields must be Full!  ");

                        return false;
                    }
                }

            }
            return true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
        
            string webSite1 = textBox_WbSite1.Text;
            string webSite2 = textBox_WbSite2.Text;
            string webSite3 = textBox_WbSite3.Text;
            string webSite4 = textBox_WbSite4.Text;
            string webSite5 = textBox_WbSite5.Text;

            string[] webArray = new string[] { webSite1, webSite2, webSite3, webSite4, webSite5 };

            SyncDownload(webArray);

            


        }


    }
}

﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //string webSite1 = textBox_WbSite1.Text;
            //string webSite2 = textBox_WbSite2.Text;
            //string webSite3 = textBox_WbSite3.Text;
            //string webSite4 = textBox_WbSite4.Text;
            //string webSite5 = textBox_WbSite5.Text;

            //string [] webArray = new string[]{ webSite1, webSite2, webSite3, webSite4, webSite5 };




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


            }

        }

        private void Display(string item , TimeSpan ts )
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                         ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            text_output.AppendText("\n" + elapsedTime + " - " + item.Substring(0, 35));

        }

        private bool Check(string[] arr)
        {
            // checking input 
            if (arr != null)
            {
                foreach (var item in arr)
                {
                    if (item == null || item.Equals(""))
                    {
                        text_output.AppendText("\n" +"Error - empty string ");

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

            string[] Test_Arr = new string[] { webSite1, webSite2 };

            SyncDownload(Test_Arr);

            


        }


    }
}

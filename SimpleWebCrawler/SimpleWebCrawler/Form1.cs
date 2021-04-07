using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace SimpleWebCrawler
{
    public partial class SimpleWebCrawler : Form
    {

        static TimeSpan totalTime;
        static bool ShowErrors = false;
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
                text_output.AppendText("\n" + "We Started Download ! ");



                for (int i = 0; i < arr.Length; i++)
                {

                    try
                    {

                        if (arr[i].Equals("Empty"))
                            continue;
                        stopWatch.Start();
                        client.DownloadString(arr[i]);
                        stopWatch.Stop();

                        TimeSpan ts = stopWatch.Elapsed;
                        Display(arr[i], ts);
                    }
                    catch (Exception ex)
                    {
                        ////text_output.AppendText("\nError BUT I WILL CONTINUE" );
                        //MessageBox.Show(ex.Message);
                        if(ShowErrors)
                        text_output.AppendText("\nWebSite"+(i+1) + ex.InnerException);
                    }
                }

                Display("Total Run Time ", totalTime);
            }

        }

        private void Display(string WebSite , TimeSpan ts )
        {
            // Display function, Displays time and website name, also total time  

            totalTime +=  ts ;

            WebSite += "--------------------------------";
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                         ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            text_output.AppendText("\n" + elapsedTime + " - " + WebSite.Substring(0, 40));


        }

        private bool Check(string[] arr)
        {
            /* checking input for null or not typed feilds ,adding "Empty" if the field is empty
             so that download function skip that element of array
            */

            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)

                {
                    string temp = arr[i];
                    arr[i] = temp.TrimStart();

                    if (arr[i] == null || arr[i].Equals(""))
                    {
                        arr[i] = "Empty";
                        if (ShowErrors)
                            text_output.AppendText("\nWebSite " + (i + 1) + " is Empty ");



                        // return false;
                    }
                }

            }
            return true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            // Refresh the richtextbox and reset total time
            text_output.ResetText();
            totalTime = new TimeSpan();
            text_output.AppendText("\n" + "Program is running ! ");

            // adding text from textbox to one array and run it in SyncDownload function
            string webSite1 = textBox_WbSite1.Text;
            string webSite2 = textBox_WbSite2.Text;
            string webSite3 = textBox_WbSite3.Text;
            string webSite4 = textBox_WbSite4.Text;
            string webSite5 = textBox_WbSite5.Text;
            string[] webArray = new string[] { webSite1, webSite2, webSite3, webSite4, webSite5 };

            SyncDownload(webArray);





        }

        private void checkBoxErrors_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxErrors.Checked)
                ShowErrors = true;
            else
                ShowErrors = false;

              
            

        }
    }
}

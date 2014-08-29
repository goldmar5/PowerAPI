#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace PowerAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client;
        string path = Directory.GetCurrentDirectory() + "\\scripts\\";
        string logFolder, logUser, logDebug, logXLS;
        string full_data;
        Excel.Application excel;
        Excel.Workbook wb;
        Excel.Worksheet ws;
        List<string> statusList = new List<string>();
        //StreamWriter debugWriter;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            textboxRead.Text += Environment.NewLine;
            statusLine.ForeColor = System.Drawing.Color.Green;
            statusLine.Text = "R E A D Y";
            TextBox.CheckForIllegalCrossThreadCalls = false;
            
            //Clear debug_log file
            //File.WriteAllText(@"d:\txt.txt", string.Empty);
            
            //Create new log file path
            logFolder = path + "logs\\log_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_').Replace(' ', '_');
            Directory.CreateDirectory(logFolder);
            Directory.CreateDirectory(logFolder + "\\debug");
            logUser = logFolder + "\\log_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_').Replace(' ', '_') + ".html";
            logDebug = logFolder + "\\debug\\debug_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_').Replace(' ', '_') + ".html";
            logXLS = logFolder + "\\log_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_').Replace(' ', '_') + ".xlsx";

            // Create *.html debug log
            StreamReader sr = new StreamReader(path + "html_header.txt");
            //debugWriter = new StreamWriter(File.Open(debugLog, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write));
            //debugWriter.Write(sr.ReadToEnd());
            using (StreamWriter sw = new StreamWriter(File.Open(logDebug, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write)))
            {
                sw.Write(sr.ReadToEnd());
                sw.Dispose();
            }

            // Create *.html user log
            StreamReader ssr = new StreamReader(path + "html_header.txt");
            using (StreamWriter sw = new StreamWriter(File.Open(logUser, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write)))
            {
                sw.Write(ssr.ReadToEnd());
                sw.Dispose();
            }           
            
            // Get all *.py files from directory
            string[] allMethods = Directory.GetFiles(path, "*.py");
            foreach (string file in allMethods)
            {
                string name = Path.GetFileName(file);
                listMethods.Items.Add(name.Remove(name.IndexOf('.')));
            }

            AddToListFromFile(path + "Types_of_devices_for_enrolling.txt", list_Types_of_devices_for_enrolling);
            AddToListFromFile(path + "States_of_panel_to_set.txt", list_States_of_panel_to_set);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            statusLine.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            statusLine.Text = "";
        }

        private void SendButton_Click(object sender, EventArgs e)
        {

            if (IsConnected())
            {
                if (textboxSend.Text.Contains("for"))
                {
                    WriteToLog("user", "");
                    foreach (string item in GetListFromListBox(listMethods))
                    {
                        WriteToLog("user", item);
                    }
                    WriteToLog("user", "#####################################");

                    WriteMethodsToXLS(GetListFromListBox(listMethods));

                    Send(client, full_data);
                }
                else
                {
                    foreach (string item in GetListFromListBox(listPanels))
                    {
                        WriteToLog("user", item);
                    }
                    WritePanelsToXLS(GetListFromListBox(listPanels));
                    Send(client, textboxSend.Text);
                }

                StartReadThread();
            }
        }

        private bool IsConnected()
        {
            if (client == null || !client.Connected)
            {
                try
                {
                    IPAddress IP = IPAddress.Parse(textboxIP.Text);
                    int port = Convert.ToInt32(textboxPORT.Text);
                    client = new TcpClient();
                    client.Connect(IP, port);
                    statusLine.ForeColor = System.Drawing.Color.Green;
                    statusLine.Text = "Connected to " + textboxIP.Text;
                    textboxIP.ReadOnly = true;
                    textboxPORT.ReadOnly = true;
                    return true;
                }
                catch (FormatException)
                {
                    statusLine.Text = "Invalid Format IP or port";
                    return false;
                }
                catch (SocketException)
                {
                    statusLine.Text = "API disabled on server or incorrect IP/port";
                    return false;
                }
            }
            return true;
        }

        private void Send(TcpClient client, string data)
        {
            // FOR DEBUG ONLY
            //using (StreamWriter sw = File.AppendText(@"d:\txt.txt"))
            //{
            //    sw.WriteLine(data);
            //}
            NetworkStream serverStream = client.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            textboxSend.Text = "";
        }

        private void Read(TcpClient client)
        {
            while (client.Connected)
            {
                NetworkStream serverStream = client.GetStream();
                while (serverStream.CanRead)
                {
                    byte[] inStream = new byte[10025];
                    try
                    {
                        serverStream.Read(inStream, 0, (int)client.ReceiveBufferSize);
                        serverStream.Flush();
                    }
                    catch (Exception)
                    {

                    }
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);         

                    if (returndata.Contains("Done"))
                    {
                        try
                        {
                            CloseConnection();
                            SendButton.Enabled = true;
                            msg(returndata);
                            //UnselectAllLists();
                        }
                        catch (System.ObjectDisposedException)
                        {

                        }

                        for (int i = 0; i < statusList.Count; i++)
                        {
                            int k, l;
                            k = ((i + listPanels.SelectedItems.Count) % listPanels.SelectedItems.Count) + 2;
                            l = (i / listPanels.SelectedItems.Count) + 2;

                            //WriteToLog("user", "k = " + k + "l = " + l);
                            WriteResultsToXLS(statusList[i], k, l);
                        }
                        logXLS = logFolder + "\\log_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_').Replace(' ', '_') + ".xlsx";
                        statusList.Clear();
                        return;
                    }

                    if (returndata.Contains("PanelsList") || returndata.Contains("bled for")) // Auto enroll enabled(disabled) for GPRS(BBA)
                    {
                        try
                        {
                            CloseConnection();
                            SendButton.Enabled = true;
                            msg(returndata);
                            WriteToLog("both", returndata);
                            //UnselectAllLists();
                            return;
                        }
                        catch (System.ObjectDisposedException)
                        {

                        }
                    }                   

                    if (!returndata.Contains("xml version") && !returndata.Contains("Panel ID:") && !returndata.Contains("FAILED") && !returndata.Contains("SUCCEEDED"))
                    {
                        msg(returndata);
                        WriteToLog("debug", returndata);
                    }                        

                    if (returndata.Contains("Panel ID:"))
                        listPanels.Items.Add(returndata.Substring(10));

                    if (returndata.Contains("FAILED"))
                    {
                        WriteToLog("both", returndata.Remove(returndata.IndexOf('.')), "failed");
                        statusList.Add(returndata.Substring(returndata.IndexOf('F'), 6));
                        
                        msg(returndata);
                    }
                        
                    if (returndata.Contains("SUCCEEDED"))
                    {
                        WriteToLog("both", returndata.Remove(returndata.IndexOf('.')), "succeeded");
                        statusList.Add("S" + returndata.Substring(returndata.IndexOf('U'), 8));
                        
                        msg(returndata);
                    }
                }
            }
        }

        public void msg(string mesg)
        {
            textboxRead.Text = textboxRead.Text + Environment.NewLine + " >> " + mesg;
        }

        private void listMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textboxSend.ResetText();
                foreach (string item in listMethods.SelectedItems)
                {
                    StreamReader sr = new StreamReader(path + item + ".py");
                    textboxSend.Text += sr.ReadToEnd() + Environment.NewLine;
                }                    

                string template_start = ReadFromFile(path + "xml_template_start.txt");
                string template_end = ReadFromFile(path + "xml_template_end.txt");
                full_data = template_start + textboxSend.Text + Environment.NewLine + template_end;
            }
            catch (FileNotFoundException)
            {
                statusLine.Text = "File GetAllpanels.xml not found in .../scripts";
            }
        }

        private void listPanels_SelectedIndexChanged(object sender, EventArgs e)
        {
            textboxSend.ResetText();
            foreach (string item in listPanels.SelectedItems)
            {
                textboxSend.Text += item.ToString().Substring(0, 6) + " ";
            }
        }

        private void list_Types_of_devices_for_enrolling_SelectedIndexChanged(object sender, EventArgs e)
        {
            textboxSend.ResetText();
            foreach (string item in list_Types_of_devices_for_enrolling.SelectedItems)
            {
                textboxSend.Text += item.ToString().Substring(0, 3) + " ";
            }
        }

        private void textboxRead_TextChanged(object sender, EventArgs e)
        {
            textboxRead.SelectionStart = textboxRead.Text.Length;
            textboxRead.ScrollToCaret();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            // Connect and Get All Panels
            if (connectButton.Text == "Connect")
            {
                listPanels.Items.Clear();
                try
                {
                    if (IsConnected())
                    {
                        StreamReader sr = new StreamReader(path + "GetAllpanels.xml");
                        Send(client, sr.ReadToEnd());
                        Thread readThread = new Thread(() => Read(client));
                        readThread.Start();
                        connectButton.Text = "Disconnect";
                        return; 
                    }
              }
                catch (FileNotFoundException)
                {
                    statusLine.Text = "File GetAllpanels.xml not found in .../scripts";
                }
                catch (Exception)
                {

                } 
            }

            if (connectButton.Text == "Disconnect")
	        {
		        try
                {
                    CloseConnection();
                    //UnselectAllLists();
                }
                catch (System.ObjectDisposedException)
                {

                }
            }
        }

        private void CloseConnection()
        {
            client.Close();
            client = null;
            statusLine.ForeColor = System.Drawing.Color.Red;
            statusLine.Text = "Disconnected from " + textboxIP.Text;
            textboxIP.ReadOnly = false;
            textboxPORT.ReadOnly = false;
            connectButton.Text = "Connect";
            //SendButton.Enabled = true;
        }

        private void AddToListFromFile(string filePath, ListBox list)
        {
            string line;
            var file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                list.Items.Add(line);
            }
        }

        private List<string> GetListFromListBox(ListBox listbox)
        {
            List<string> itemsList = new List<string>();
            foreach (string item in listbox.SelectedItems)
            {                
                if (item.Contains('['))
                    itemsList.Add(item.Remove(item.IndexOf('[')));
                else
                    itemsList.Add(item);
            }
            return itemsList;
        }

        private string ReadFromFile(string filePath)
        {
            string line, text = "";
            var file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                text = text + line + Environment.NewLine;
            }
            file.Close();
            return text;
        }

        
        /// <summary>
        /// Write info to the log
        /// </summary>
        /// <param name="log_type">"debug", "user" or "both"</param>
        /// <param name="data">what do you need to write</param>
        /// <param name="id">"failed", "succeeded"</param>
        private void WriteToLog(string log_type, string data, string id = "info")
        {          
            if (log_type == "debug")
                WriteToDEBUG(data, id);
            if (log_type == "user")
                WriteToUSER(data, id);
            if (log_type == "both")
            {
                WriteToDEBUG(data, id);
                WriteToUSER(data, id);
            }
        }

        private void WriteMethodsToXLS(List<string> data)
        {            
            OpenOrCreateExcel(out excel, out wb, out ws);

            for (int i = 2; i < data.Count + 2; i++)
            {
                ws.Cells[1, i] = data[i - 2];
            }

            SaveAndCloseExcel();
        }        

        private void WritePanelsToXLS(List<string> data)
        {
            OpenOrCreateExcel(out excel, out wb, out ws);

            for (int i = 2; i < data.Count + 2; i++)
            {
                ws.Cells[i, 1] = data[i - 2];
            }

            SaveAndCloseExcel();
        }

        private void WriteResultsToXLS(string data, int i, int j)
        {
            try
            {
                OpenOrCreateExcel(out excel, out wb, out ws);

                ws.Cells[i, j] = data;
            }
            catch (FileNotFoundException)
            {
                WriteToLog("user", "FUCKING FAIL", "failed");
            }
            finally
            {
                SaveAndCloseExcel();
            }
                
        }

        private void OpenOrCreateExcel(out Excel.Application excel, out Excel.Workbook wb, out Excel.Worksheet ws)
        {
            excel = new Excel.Application();

            FileInfo exFile = new FileInfo(logXLS);
            if (!exFile.Exists)
                wb = excel.Workbooks.Add();
            else
                wb = excel.Workbooks.Open(logXLS);

            ws = wb.ActiveSheet;
            ws.get_Range("A1", "A5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("A1", "A5000").Cells.Font.Bold = true;
            ws.get_Range("B1", "B5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("C1", "C5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("D1", "D5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("E1", "E5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("F1", "F5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("G1", "G5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("H1", "H5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("I1", "I5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("J1", "J5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("K1", "K5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            ws.get_Range("L1", "L5000").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            //for (int i = 1; i <= 20; i++)
            //{
            //    Excel.Range range = ws.get_Range("B" + i.ToString(), "J" + i.ToString());
            //    ws.get_Range("B1", "B15").Font.Color = ColorTranslator.ToOle(Color.Red);
            //}
        }

        private void SaveAndCloseExcel()
        {
            excel.DisplayAlerts = false;
            wb.SaveAs(logXLS);
            wb.Close();
            excel.Quit();
            excel.DisplayAlerts = false;
        }        

        #region WriteToLogs
        /// <summary>
        /// Write info to the USER log
        /// </summary>
        /// <param name="data">what do you need to write</param>
        /// <param name="id">"failed", "succeeded" (according to the HTML classes)</param>
        private void WriteToUSER(string data, string id = "info")
        {
            using (StreamWriter sw = new StreamWriter(File.Open(logUser, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write)))
                sw.WriteLine("<div class='" + id + "'><span>" + DateTime.Now.ToString() + "</span>   <span>" + data + "</span></div>");
        }
        
        /// <summary>
        /// Write info to the DEBUG log
        /// </summary>
        /// <param name="data">what do you need to write</param>
        /// <param name="id">"failed", "succeeded" (according to the HTML classes)</param>
        private void WriteToDEBUG(string data, string id = "info")
        {
            //debugWriter.WriteLine("<div class='" + id + "'><span>" + DateTime.Now.ToString() + "</span>   <span>" + data + "</span></div>");
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(logDebug, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write)))
                {
                    sw.WriteLine("<div class='" + id + "'><span>" + DateTime.Now.ToString() + "</span>   <span>" + data + "</span></div>");
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }               
        }
        #endregion

        private void UnselectAllLists()
        {
            listPanels.ClearSelected();
            list_Types_of_devices_for_enrolling.ClearSelected();
            listMethods.ClearSelected();
        }

        private void goToResultsButton_Click(object sender, EventArgs e)
        {
            Process.Start(logFolder);
        }

        private void enableAutoEnrollGPRS_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "EnableAutoEnrollGPRS.xml"));
                StartReadThread();
            }
        }

        private void disableAutoEnrollGPRS_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "DisableAutoEnrollGPRS.xml"));
                StartReadThread();
            }
        }

        private void enableAutoEnrollBBA_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "EnableAutoEnrollBBA.xml"));
                StartReadThread();
            }
        }

        private void disableAutoEnrollBBA_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "DisableAutoEnrollBBA.xml"));
                StartReadThread();
            }
        }

        private void StartReadThread()
        {
            Thread readThread = new Thread(() => Read(client));
            try
            {
                readThread.Start();
            }
            catch
            {
                readThread.Abort();
            }
            connectButton.Text = "Disconnect";
        }

        private void EnrollPanelsButton_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "AddPanels.xml"));
                StartReadThread();
            }
        }

        private void RemovePanelsButton_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                Send(client, ReadFromFile(path + "RemovePanels.xml"));
                StartReadThread();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Excel;

namespace Renamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Get Source Folder";
            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog() == DialogResult.OK) {
                sSourceFolder.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Get Destination Folder";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK) {
                sDestFolder.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            fd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            fd.Title = "Select an Excel File";
            fd.Filter = "Excel Files (.xlsx, .xls)|*.xlsx;*.xls";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                sExcelFile.Text = fd.FileName;
                FileStream stream = File.Open(fd.FileName, FileMode.Open, FileAccess.Read);
                sExcelFile.Text = Path.GetExtension(fd.FileName);
                if (Path.GetExtension(fd.FileName) == ".xls") {
                    //TODO: Move this to a public scope. 
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    Console.Write("Data Read OK");
                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet result = excelReader.AsDataSet();
                    string[] columnNamesFrom = result.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    string[] columnNamesTo = result.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    fldLookUpVal.DataSource = columnNamesFrom;
                    fldLookupValTo.DataSource = columnNamesTo;
                    excelReader.Close();

                }
                else {
                    MessageBox.Show("Right now we're only supporting .XLS files because that's the datasource I needed for this project. I'll fix this later.");
                    // IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }



            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private class SpreadsheetColumns {
            public string Name { get; set; }
            public SpreadsheetColumns(string _name) {
                Name = _name;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //put together a stringbuilder to make the logginess...
            StringBuilder sResults = new StringBuilder("");
            sResults.AppendLine("Beginning Process...");
            //TODO: Add validation, son.
            string[] arrSrcFiles = Directory.GetFiles(sSourceFolder.Text);
            foreach (string FileName in arrSrcFiles) {
                sResults.AppendLine(RenameFile(FileName));
            }

            //SHOW ME THE LOGINESS!!1!
            MessageBox.Show(sResults.ToString());

        }

        private string RenameFile(string FileName)
        {//TODO: Make this *actually* do the renaming. You will want to add the Excel file into global scope so you can get to it.
            return FileName;
        }
    }

}
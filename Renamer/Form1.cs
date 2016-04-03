using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (Path.GetExtension(fd.FileName) == ".xls") {
                    DataSet result = ExcelData.Data(fd.FileName);
                    string[] columnNamesFrom = result.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    string[] columnNamesTo = result.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                    fldLookUpVal.DataSource = columnNamesFrom;
                    fldLookupValTo.DataSource = columnNamesTo;      
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
            if (!ValidateInput()) { return; }

            string[] arrSrcFiles = Directory.GetFiles(sSourceFolder.Text);
            foreach (string FileName in arrSrcFiles) {
                sResults.AppendLine(RenameFile(FileName));
            }

            //SHOW ME THE LOGINESS!!1!
            MessageBox.Show(sResults.ToString());

        }

        private string RenameFile(string FileName)
        {//TODO: Make this *actually* do the renaming. You will want to add the Excel file into global scope so you can get to it.
            if (!File.Exists(FileName))
            {
                return  "No Such Thing.";
            }
            //setip destination path
            StringBuilder sDest = new StringBuilder(sDestFolder.Text);
            if (! sDest.ToString().EndsWith(@"\")){ sDest.Append(@"\"); }

            ///now the tricky bit - I have to look up the new ID based on the old ID
            Regex rgx = new Regex(@regExpression.Text);
            Match m = rgx.Match(FileName);
            string newvalue = ExcelData.GetDestValue(fldLookUpVal.SelectedValue.ToString(), fldLookupValTo.SelectedValue.ToString(), m.ToString(), sExcelFile.Text.ToString());
            string justfilename = Path.GetFileName(FileName);
            string newname = rgx.Replace(justfilename, newvalue);
            string destination = sDest.Append(newname).ToString();

            // I LIKE TO MOVE IT MOVE IT...

            // Ensure that the target does not exist.
            if (File.Exists(destination))
                File.Delete(destination);

            // Move the file.
            File.Copy(FileName, destination);
            Console.WriteLine("{0} was moved to {1}.", FileName, destination);
            return destination;
        }

        private Boolean ValidateInput()
        { //TODO: Add validation, son.
            if (sSourceFolder.TextLength < 5) { MessageBox.Show("Must specify a source directory"); return false; }
            else { return true; }
        }
        public static class ExcelData {
            public static void TellMe() { MessageBox.Show("I ran this!");}
            
            public static string GetDestValue(string srcCol, string dstCol, string lkupVal, string filename) {

                DataSet columns = Data(filename);
                //TODO: create the lookup that finds lkupVal in srcCol and returns correcponding dstCol
                DataRow[] foundRow = columns.Tables[0].Select("["+srcCol + "]='" + lkupVal+"'");
                return foundRow[0].Field<string>(dstCol);
            }

            public static DataSet Data(string filename) {
                FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                Console.Write("Data Read in static OK");
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                excelReader.Close();
                return result;
            }
        }
    }

}
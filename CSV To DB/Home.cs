using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace CSV_To_DB
{
    public partial class Home : Form
    {
        private string _pathCSVSelezionato = "";
        private string _configPath;

        public Home(string configPath)
        {
            InitializeComponent();
            _configPath = configPath;
            if (File.Exists(_configPath))
                this.connectionString_textBox1.Text = File.ReadAllText(_configPath);
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_configPath));
            }
            this.separator_comboBox.SelectedIndex = 0;
        }


        private void AggiungiFile_Click(object sender, EventArgs e)
        {
            var filePicker = new System.Windows.Forms.OpenFileDialog();
            if (filePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _pathCSVSelezionato = filePicker.FileName;
                pathCSV_textBox.Text = _pathCSVSelezionato;
            }
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            string pathToCSV = pathCSV_textBox.Text;
            string separator = (string)separator_comboBox.SelectedItem;

            var importManager = new ImportManager(schemaTable_textBox.Text, connectionString_textBox1.Text);

            DataTable dataTable = importManager.ParseToDataTable(pathToCSV, separator[0]);

            try
            {
                if (nuovaTable_checkBox.Checked)
                {
                    importManager.CreateTable(dataTable);
                }
                importManager.ImportCSVToDatabase(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel);
            }

        }

        private void connectionString_TextLeave(object sender, EventArgs e)
        {
            File.WriteAllText(_configPath, connectionString_textBox1.Text);
        }

        private void CheckConnection_Click(object sender, EventArgs e)
        {
            string connectionString = connectionString_textBox1.Text;

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    MessageBox.Show("Connessione riuscita!");
                }
                catch (SqlException sex)
                {
                    MessageBox.Show($"Connessione fallita :(\n{sex.Message}");

                }
                finally
                {
                    conn.Close();
                }
            }
            catch (ArgumentException aex)
            {

                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void separator_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

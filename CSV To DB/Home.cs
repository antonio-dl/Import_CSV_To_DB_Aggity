using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public Home()
        {
            InitializeComponent();

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
            var importManager = new ImportManager(schemaTable_textBox.Text, connectionString_textBox1.Text);

            string separator = (string)separator_comboBox.SelectedItem;

            try
            {
                importManager.ImportCSVToDatabase(pathCSV_textBox.Text, separator[0]);
            }
            catch (Exception)
            {

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

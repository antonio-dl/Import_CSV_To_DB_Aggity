namespace CSV_To_DB
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionString_textBox1 = new System.Windows.Forms.TextBox();
            this.pathCSV_textBox = new System.Windows.Forms.TextBox();
            this.schemaTable_textBox = new System.Windows.Forms.TextBox();
            this.import_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_selectFile = new System.Windows.Forms.Button();
            this.separator_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nuovaTable_checkBox = new System.Windows.Forms.CheckBox();
            this.checkConnection_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectionString_textBox1
            // 
            this.connectionString_textBox1.Location = new System.Drawing.Point(56, 133);
            this.connectionString_textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connectionString_textBox1.Name = "connectionString_textBox1";
            this.connectionString_textBox1.Size = new System.Drawing.Size(312, 27);
            this.connectionString_textBox1.TabIndex = 0;
            this.connectionString_textBox1.Text = "Connection String";
            this.connectionString_textBox1.Leave += new System.EventHandler(this.connectionString_TextLeave);
            // 
            // pathCSV_textBox
            // 
            this.pathCSV_textBox.Location = new System.Drawing.Point(56, 32);
            this.pathCSV_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathCSV_textBox.Name = "pathCSV_textBox";
            this.pathCSV_textBox.Size = new System.Drawing.Size(312, 27);
            this.pathCSV_textBox.TabIndex = 1;
            this.pathCSV_textBox.Text = "Path .csv";
            // 
            // schemaTable_textBox
            // 
            this.schemaTable_textBox.Location = new System.Drawing.Point(56, 183);
            this.schemaTable_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.schemaTable_textBox.Name = "schemaTable_textBox";
            this.schemaTable_textBox.Size = new System.Drawing.Size(312, 27);
            this.schemaTable_textBox.TabIndex = 2;
            this.schemaTable_textBox.Text = "schema.table";
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(59, 266);
            this.import_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(126, 51);
            this.import_button.TabIndex = 3;
            this.import_button.Text = "Import to DB";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(492, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 71);
            this.label1.TabIndex = 4;
            this.label1.Text = "Il file CSV deve avere nella prima riga esattamente i nomi delle colonne della ta" +
    "bella";
            // 
            // button_selectFile
            // 
            this.button_selectFile.Location = new System.Drawing.Point(387, 21);
            this.button_selectFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_selectFile.Name = "button_selectFile";
            this.button_selectFile.Size = new System.Drawing.Size(99, 48);
            this.button_selectFile.TabIndex = 5;
            this.button_selectFile.Text = "Scegli";
            this.button_selectFile.UseVisualStyleBackColor = true;
            this.button_selectFile.Click += new System.EventHandler(this.AggiungiFile_Click);
            // 
            // separator_comboBox
            // 
            this.separator_comboBox.FormattingEnabled = true;
            this.separator_comboBox.Items.AddRange(new object[] {
            ";",
            ","});
            this.separator_comboBox.Location = new System.Drawing.Point(216, 66);
            this.separator_comboBox.Name = "separator_comboBox";
            this.separator_comboBox.Size = new System.Drawing.Size(152, 28);
            this.separator_comboBox.TabIndex = 6;
            this.separator_comboBox.SelectedIndexChanged += new System.EventHandler(this.separator_comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Separatore CSV";
            // 
            // nuovaTable_checkBox
            // 
            this.nuovaTable_checkBox.AutoSize = true;
            this.nuovaTable_checkBox.Location = new System.Drawing.Point(56, 217);
            this.nuovaTable_checkBox.Name = "nuovaTable_checkBox";
            this.nuovaTable_checkBox.Size = new System.Drawing.Size(132, 24);
            this.nuovaTable_checkBox.TabIndex = 8;
            this.nuovaTable_checkBox.Text = "Nuova Tabella?";
            this.nuovaTable_checkBox.UseVisualStyleBackColor = true;
            // 
            // checkConnection_button
            // 
            this.checkConnection_button.Location = new System.Drawing.Point(387, 133);
            this.checkConnection_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkConnection_button.Name = "checkConnection_button";
            this.checkConnection_button.Size = new System.Drawing.Size(99, 27);
            this.checkConnection_button.TabIndex = 9;
            this.checkConnection_button.Text = "Check";
            this.checkConnection_button.UseVisualStyleBackColor = true;
            this.checkConnection_button.Click += new System.EventHandler(this.CheckConnection_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.checkConnection_button);
            this.Controls.Add(this.nuovaTable_checkBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.separator_comboBox);
            this.Controls.Add(this.button_selectFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.schemaTable_textBox);
            this.Controls.Add(this.pathCSV_textBox);
            this.Controls.Add(this.connectionString_textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Home";
            this.RightToLeftLayout = true;
            this.Text = "CSV to DB Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox connectionString_textBox1;
        private System.Windows.Forms.TextBox pathCSV_textBox;
        private System.Windows.Forms.TextBox schemaTable_textBox;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_selectFile;
        private ComboBox separator_comboBox;
        private Label label2;
        private CheckBox nuovaTable_checkBox;
        private Button checkConnection_button;
    }
}


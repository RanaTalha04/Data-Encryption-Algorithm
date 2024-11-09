namespace DES_Algo
{
    partial class DES
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            heading_lbl = new Label();
            readfile_bttn = new Button();
            filePath_lbl = new Label();
            KeyInput_lbl = new Label();
            operation_lbl = new Label();
            completeness_bar = new ProgressBar();
            Start_Bttn = new Button();
            filePath_tb = new TextBox();
            masterKey_tb = new TextBox();
            Encryption_CB = new CheckBox();
            Decryption_CB = new CheckBox();
            or_lbl = new Label();
            Status_lbl = new Label();
            Success_lbl = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // heading_lbl
            // 
            heading_lbl.AutoSize = true;
            heading_lbl.Font = new Font("Sans Serif Collection", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            heading_lbl.ForeColor = SystemColors.Control;
            heading_lbl.Location = new Point(249, 26);
            heading_lbl.Name = "heading_lbl";
            heading_lbl.Size = new Size(382, 56);
            heading_lbl.TabIndex = 0;
            heading_lbl.Text = "DES Encryption Tool";
            // 
            // readfile_bttn
            // 
            readfile_bttn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            readfile_bttn.ForeColor = Color.FromArgb(64, 64, 64);
            readfile_bttn.Location = new Point(504, 166);
            readfile_bttn.Name = "readfile_bttn";
            readfile_bttn.Size = new Size(94, 35);
            readfile_bttn.TabIndex = 1;
            readfile_bttn.Text = "Browse";
            readfile_bttn.UseVisualStyleBackColor = true;
            readfile_bttn.Click += readfile_bttn_Click;
            // 
            // filePath_lbl
            // 
            filePath_lbl.AutoSize = true;
            filePath_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            filePath_lbl.ForeColor = Color.White;
            filePath_lbl.Location = new Point(109, 109);
            filePath_lbl.Name = "filePath_lbl";
            filePath_lbl.Size = new Size(80, 23);
            filePath_lbl.TabIndex = 3;
            filePath_lbl.Text = "File Path:";
            // 
            // KeyInput_lbl
            // 
            KeyInput_lbl.AutoSize = true;
            KeyInput_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            KeyInput_lbl.ForeColor = Color.White;
            KeyInput_lbl.Location = new Point(109, 221);
            KeyInput_lbl.Name = "KeyInput_lbl";
            KeyInput_lbl.Size = new Size(145, 23);
            KeyInput_lbl.TabIndex = 4;
            KeyInput_lbl.Text = "Enter Master Key:";
            // 
            // operation_lbl
            // 
            operation_lbl.AutoSize = true;
            operation_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            operation_lbl.ForeColor = Color.White;
            operation_lbl.Location = new Point(109, 322);
            operation_lbl.Name = "operation_lbl";
            operation_lbl.Size = new Size(141, 23);
            operation_lbl.TabIndex = 5;
            operation_lbl.Text = "Select Operation:";
            // 
            // completeness_bar
            // 
            completeness_bar.Location = new Point(270, 593);
            completeness_bar.Name = "completeness_bar";
            completeness_bar.Size = new Size(313, 29);
            completeness_bar.TabIndex = 6;
            // 
            // Start_Bttn
            // 
            Start_Bttn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Start_Bttn.ForeColor = Color.FromArgb(64, 64, 64);
            Start_Bttn.Location = new Point(345, 480);
            Start_Bttn.Name = "Start_Bttn";
            Start_Bttn.Size = new Size(148, 42);
            Start_Bttn.TabIndex = 7;
            Start_Bttn.Text = "Start Operation";
            Start_Bttn.UseVisualStyleBackColor = true;
            Start_Bttn.Click += Start_Bttn_Click;
            // 
            // filePath_tb
            // 
            filePath_tb.Location = new Point(109, 155);
            filePath_tb.Multiline = true;
            filePath_tb.Name = "filePath_tb";
            filePath_tb.Size = new Size(281, 46);
            filePath_tb.TabIndex = 8;
            // 
            // masterKey_tb
            // 
            masterKey_tb.Location = new Point(109, 259);
            masterKey_tb.Multiline = true;
            masterKey_tb.Name = "masterKey_tb";
            masterKey_tb.Size = new Size(281, 46);
            masterKey_tb.TabIndex = 9;
            // 
            // Encryption_CB
            // 
            Encryption_CB.AutoSize = true;
            Encryption_CB.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Encryption_CB.Location = new Point(118, 367);
            Encryption_CB.Name = "Encryption_CB";
            Encryption_CB.Size = new Size(115, 27);
            Encryption_CB.TabIndex = 10;
            Encryption_CB.Text = "Encryption";
            Encryption_CB.UseVisualStyleBackColor = true;
            // 
            // Decryption_CB
            // 
            Decryption_CB.AutoSize = true;
            Decryption_CB.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Decryption_CB.Location = new Point(270, 370);
            Decryption_CB.Name = "Decryption_CB";
            Decryption_CB.Size = new Size(117, 27);
            Decryption_CB.TabIndex = 11;
            Decryption_CB.Text = "Decryption";
            Decryption_CB.UseVisualStyleBackColor = true;
            // 
            // or_lbl
            // 
            or_lbl.AutoSize = true;
            or_lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            or_lbl.ForeColor = Color.White;
            or_lbl.Location = new Point(426, 175);
            or_lbl.Name = "or_lbl";
            or_lbl.Size = new Size(29, 20);
            or_lbl.TabIndex = 12;
            or_lbl.Text = "OR";
            // 
            // Status_lbl
            // 
            Status_lbl.AutoSize = true;
            Status_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Status_lbl.ForeColor = Color.White;
            Status_lbl.Location = new Point(156, 651);
            Status_lbl.Name = "Status_lbl";
            Status_lbl.Size = new Size(61, 23);
            Status_lbl.TabIndex = 13;
            Status_lbl.Text = "Status:";
            Status_lbl.Visible = false;
            // 
            // Success_lbl
            // 
            Success_lbl.AutoSize = true;
            Success_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Success_lbl.ForeColor = Color.White;
            Success_lbl.Location = new Point(377, 651);
            Success_lbl.Name = "Success_lbl";
            Success_lbl.Size = new Size(53, 23);
            Success_lbl.TabIndex = 14;
            Success_lbl.Text = "label1";
            Success_lbl.Visible = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(516, 243);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(180, 141);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "";
            // 
            // DES
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(855, 703);
            Controls.Add(richTextBox1);
            Controls.Add(Success_lbl);
            Controls.Add(Status_lbl);
            Controls.Add(or_lbl);
            Controls.Add(Decryption_CB);
            Controls.Add(Encryption_CB);
            Controls.Add(masterKey_tb);
            Controls.Add(filePath_tb);
            Controls.Add(Start_Bttn);
            Controls.Add(completeness_bar);
            Controls.Add(operation_lbl);
            Controls.Add(KeyInput_lbl);
            Controls.Add(filePath_lbl);
            Controls.Add(readfile_bttn);
            Controls.Add(heading_lbl);
            ForeColor = SystemColors.ControlLight;
            Name = "DES";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DES";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label heading_lbl;
        private Button readfile_bttn;
        private Label filePath_lbl;
        private Label KeyInput_lbl;
        private Label operation_lbl;
        private ProgressBar completeness_bar;
        private Button Start_Bttn;
        private TextBox filePath_tb;
        private TextBox masterKey_tb;
        private CheckBox Encryption_CB;
        private CheckBox Decryption_CB;
        private Label or_lbl;
        private Label Status_lbl;
        private Label Success_lbl;
        private RichTextBox richTextBox1;
    }
}

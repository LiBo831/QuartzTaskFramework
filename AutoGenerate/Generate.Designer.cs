
namespace AutoGenerate
{
    partial class Generate
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
            this.DataSource_textBox = new System.Windows.Forms.TextBox();
            this.Generate_button = new System.Windows.Forms.Button();
            this.Table_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SqlServer_radioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MySql_radioButton = new System.Windows.Forms.RadioButton();
            this.PostgreSQL_radioButton = new System.Windows.Forms.RadioButton();
            this.Oracle_radioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSource_textBox
            // 
            this.DataSource_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSource_textBox.Location = new System.Drawing.Point(6, 69);
            this.DataSource_textBox.Multiline = true;
            this.DataSource_textBox.Name = "DataSource_textBox";
            this.DataSource_textBox.Size = new System.Drawing.Size(534, 132);
            this.DataSource_textBox.TabIndex = 0;
            this.DataSource_textBox.Text = "Data Source=1.1.10.8;DataBase=WaterProject;uid=sa;pwd=234.com;Integrated Security" +
    "=False;User Instance=False;";
            // 
            // Generate_button
            // 
            this.Generate_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate_button.Location = new System.Drawing.Point(465, 207);
            this.Generate_button.Name = "Generate_button";
            this.Generate_button.Size = new System.Drawing.Size(75, 23);
            this.Generate_button.TabIndex = 1;
            this.Generate_button.Text = "生成";
            this.Generate_button.UseVisualStyleBackColor = true;
            this.Generate_button.Click += new System.EventHandler(this.Generate_button_Click);
            // 
            // Table_textBox
            // 
            this.Table_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Table_textBox.Location = new System.Drawing.Point(116, 11);
            this.Table_textBox.Name = "Table_textBox";
            this.Table_textBox.Size = new System.Drawing.Size(424, 21);
            this.Table_textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "指定生成的表名:";
            // 
            // SqlServer_radioButton
            // 
            this.SqlServer_radioButton.Checked = true;
            this.SqlServer_radioButton.Location = new System.Drawing.Point(3, 3);
            this.SqlServer_radioButton.Name = "SqlServer_radioButton";
            this.SqlServer_radioButton.Size = new System.Drawing.Size(77, 16);
            this.SqlServer_radioButton.TabIndex = 4;
            this.SqlServer_radioButton.TabStop = true;
            this.SqlServer_radioButton.Text = "SqlServer";
            this.SqlServer_radioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.DataSource_textBox);
            this.groupBox1.Controls.Add(this.Generate_button);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Table_textBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 238);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.SqlServer_radioButton);
            this.flowLayoutPanel1.Controls.Add(this.MySql_radioButton);
            this.flowLayoutPanel1.Controls.Add(this.PostgreSQL_radioButton);
            this.flowLayoutPanel1.Controls.Add(this.Oracle_radioButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(534, 22);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // MySql_radioButton
            // 
            this.MySql_radioButton.Location = new System.Drawing.Point(86, 3);
            this.MySql_radioButton.Name = "MySql_radioButton";
            this.MySql_radioButton.Size = new System.Drawing.Size(53, 16);
            this.MySql_radioButton.TabIndex = 6;
            this.MySql_radioButton.Text = "MySql";
            this.MySql_radioButton.UseVisualStyleBackColor = true;
            // 
            // PostgreSQL_radioButton
            // 
            this.PostgreSQL_radioButton.Location = new System.Drawing.Point(145, 3);
            this.PostgreSQL_radioButton.Name = "PostgreSQL_radioButton";
            this.PostgreSQL_radioButton.Size = new System.Drawing.Size(83, 16);
            this.PostgreSQL_radioButton.TabIndex = 7;
            this.PostgreSQL_radioButton.Text = "PostgreSQL";
            this.PostgreSQL_radioButton.UseVisualStyleBackColor = true;
            // 
            // Oracle_radioButton
            // 
            this.Oracle_radioButton.Location = new System.Drawing.Point(234, 3);
            this.Oracle_radioButton.Name = "Oracle_radioButton";
            this.Oracle_radioButton.Size = new System.Drawing.Size(59, 16);
            this.Oracle_radioButton.TabIndex = 8;
            this.Oracle_radioButton.Text = "Oracle";
            this.Oracle_radioButton.UseVisualStyleBackColor = true;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 238);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Generate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox DataSource_textBox;
        private System.Windows.Forms.Button Generate_button;
        private System.Windows.Forms.TextBox Table_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton SqlServer_radioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton MySql_radioButton;
        private System.Windows.Forms.RadioButton PostgreSQL_radioButton;
        private System.Windows.Forms.RadioButton Oracle_radioButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
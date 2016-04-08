namespace App.Generator
{
    partial class GeneratorForm
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
            this.btGenerate = new System.Windows.Forms.Button();
            this.btSelectProject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbProjectFolder = new System.Windows.Forms.Label();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbModuleList = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btRemoveModules = new System.Windows.Forms.Button();
            this.clbModuleList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btGenerate
            // 
            this.btGenerate.Location = new System.Drawing.Point(49, 124);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(112, 23);
            this.btGenerate.TabIndex = 0;
            this.btGenerate.Text = "Generate";
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // btSelectProject
            // 
            this.btSelectProject.Location = new System.Drawing.Point(46, 35);
            this.btSelectProject.Name = "btSelectProject";
            this.btSelectProject.Size = new System.Drawing.Size(115, 23);
            this.btSelectProject.TabIndex = 2;
            this.btSelectProject.Text = "Select Project Folder";
            this.btSelectProject.UseVisualStyleBackColor = true;
            this.btSelectProject.Click += new System.EventHandler(this.btSelectProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "3.";
            // 
            // lbProjectFolder
            // 
            this.lbProjectFolder.AutoSize = true;
            this.lbProjectFolder.Location = new System.Drawing.Point(180, 36);
            this.lbProjectFolder.Name = "lbProjectFolder";
            this.lbProjectFolder.Size = new System.Drawing.Size(10, 13);
            this.lbProjectFolder.TabIndex = 5;
            this.lbProjectFolder.Text = " ";
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(183, 97);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.Size = new System.Drawing.Size(136, 20);
            this.tbModelName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Enter new model name";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMessage.Location = new System.Drawing.Point(49, 159);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 13);
            this.lbMessage.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "4.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "5.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "2.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbModuleList);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 182);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Model";
            // 
            // cbModuleList
            // 
            this.cbModuleList.FormattingEnabled = true;
            this.cbModuleList.Location = new System.Drawing.Point(171, 56);
            this.cbModuleList.Name = "cbModuleList";
            this.cbModuleList.Size = new System.Drawing.Size(136, 21);
            this.cbModuleList.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select module name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btRemoveModules);
            this.groupBox2.Controls.Add(this.clbModuleList);
            this.groupBox2.Location = new System.Drawing.Point(350, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 301);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove Module";
            // 
            // btRemoveModules
            // 
            this.btRemoveModules.Location = new System.Drawing.Point(7, 270);
            this.btRemoveModules.Name = "btRemoveModules";
            this.btRemoveModules.Size = new System.Drawing.Size(131, 23);
            this.btRemoveModules.TabIndex = 1;
            this.btRemoveModules.Text = "Remove";
            this.btRemoveModules.UseVisualStyleBackColor = true;
            this.btRemoveModules.Click += new System.EventHandler(this.btRemoveModules_Click);
            // 
            // clbModuleList
            // 
            this.clbModuleList.FormattingEnabled = true;
            this.clbModuleList.Location = new System.Drawing.Point(6, 19);
            this.clbModuleList.Name = "clbModuleList";
            this.clbModuleList.Size = new System.Drawing.Size(132, 244);
            this.clbModuleList.TabIndex = 0;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 328);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbModelName);
            this.Controls.Add(this.lbProjectFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSelectProject);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(300, 300);
            this.Name = "GeneratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boilerplate Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGenerate;
        private System.Windows.Forms.Button btSelectProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbProjectFolder;
        private System.Windows.Forms.TextBox tbModelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btRemoveModules;
        private System.Windows.Forms.CheckedListBox clbModuleList;
        private System.Windows.Forms.ComboBox cbModuleList;
    }
}


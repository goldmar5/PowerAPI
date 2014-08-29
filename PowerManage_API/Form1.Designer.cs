namespace PowerAPI
{
    partial class Form1
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
            this.textboxIP = new System.Windows.Forms.TextBox();
            this.textboxPORT = new System.Windows.Forms.TextBox();
            this.textboxRead = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.textboxSend = new System.Windows.Forms.TextBox();
            this.statusLine = new System.Windows.Forms.Label();
            this.listMethods = new System.Windows.Forms.ListBox();
            this.listPanels = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.list_Types_of_devices_for_enrolling = new System.Windows.Forms.ListBox();
            this.list_States_of_panel_to_set = new System.Windows.Forms.ListBox();
            this.goToResultsButton = new System.Windows.Forms.Button();
            this.enableAutoEnrollGPRS = new System.Windows.Forms.Button();
            this.disableAutoEnrollGPRS = new System.Windows.Forms.Button();
            this.enableAutoEnrollBBA = new System.Windows.Forms.Button();
            this.disableAutoEnrollBBA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EnrollPanelsButton = new System.Windows.Forms.Button();
            this.RemovePanelsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxIP
            // 
            this.textboxIP.Location = new System.Drawing.Point(12, 11);
            this.textboxIP.Name = "textboxIP";
            this.textboxIP.Size = new System.Drawing.Size(125, 20);
            this.textboxIP.TabIndex = 1;
            this.textboxIP.Text = "94.125.125.xxx";
            this.textboxIP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textboxPORT
            // 
            this.textboxPORT.Location = new System.Drawing.Point(143, 11);
            this.textboxPORT.Name = "textboxPORT";
            this.textboxPORT.Size = new System.Drawing.Size(60, 20);
            this.textboxPORT.TabIndex = 2;
            this.textboxPORT.Text = "4444";
            this.textboxPORT.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textboxRead
            // 
            this.textboxRead.Cursor = System.Windows.Forms.Cursors.Default;
            this.textboxRead.Location = new System.Drawing.Point(12, 37);
            this.textboxRead.Multiline = true;
            this.textboxRead.Name = "textboxRead";
            this.textboxRead.ReadOnly = true;
            this.textboxRead.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxRead.Size = new System.Drawing.Size(552, 188);
            this.textboxRead.TabIndex = 3;
            this.textboxRead.TextChanged += new System.EventHandler(this.textboxRead_TextChanged);
            // 
            // SendButton
            // 
            this.SendButton.Enabled = false;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(12, 532);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(552, 78);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // textboxSend
            // 
            this.textboxSend.Location = new System.Drawing.Point(12, 236);
            this.textboxSend.Multiline = true;
            this.textboxSend.Name = "textboxSend";
            this.textboxSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxSend.Size = new System.Drawing.Size(552, 290);
            this.textboxSend.TabIndex = 6;
            // 
            // statusLine
            // 
            this.statusLine.AutoSize = true;
            this.statusLine.Font = new System.Drawing.Font("Batang", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLine.Location = new System.Drawing.Point(301, 15);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(70, 16);
            this.statusLine.TabIndex = 7;
            this.statusLine.Text = "READY";
            // 
            // listMethods
            // 
            this.listMethods.FormattingEnabled = true;
            this.listMethods.Location = new System.Drawing.Point(570, 231);
            this.listMethods.Name = "listMethods";
            this.listMethods.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listMethods.Size = new System.Drawing.Size(137, 290);
            this.listMethods.TabIndex = 9;
            this.listMethods.SelectedIndexChanged += new System.EventHandler(this.listMethods_SelectedIndexChanged);
            // 
            // listPanels
            // 
            this.listPanels.FormattingEnabled = true;
            this.listPanels.Location = new System.Drawing.Point(570, 39);
            this.listPanels.Name = "listPanels";
            this.listPanels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPanels.Size = new System.Drawing.Size(137, 186);
            this.listPanels.TabIndex = 10;
            this.listPanels.SelectedIndexChanged += new System.EventHandler(this.listPanels_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(220, 11);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 11;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // list_Types_of_devices_for_enrolling
            // 
            this.list_Types_of_devices_for_enrolling.FormattingEnabled = true;
            this.list_Types_of_devices_for_enrolling.Location = new System.Drawing.Point(890, 39);
            this.list_Types_of_devices_for_enrolling.Name = "list_Types_of_devices_for_enrolling";
            this.list_Types_of_devices_for_enrolling.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_Types_of_devices_for_enrolling.Size = new System.Drawing.Size(45, 563);
            this.list_Types_of_devices_for_enrolling.TabIndex = 12;
            this.list_Types_of_devices_for_enrolling.SelectedIndexChanged += new System.EventHandler(this.list_Types_of_devices_for_enrolling_SelectedIndexChanged);
            // 
            // list_States_of_panel_to_set
            // 
            this.list_States_of_panel_to_set.FormattingEnabled = true;
            this.list_States_of_panel_to_set.Location = new System.Drawing.Point(710, 231);
            this.list_States_of_panel_to_set.Name = "list_States_of_panel_to_set";
            this.list_States_of_panel_to_set.Size = new System.Drawing.Size(174, 186);
            this.list_States_of_panel_to_set.TabIndex = 13;
            // 
            // goToResultsButton
            // 
            this.goToResultsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToResultsButton.Location = new System.Drawing.Point(570, 532);
            this.goToResultsButton.Name = "goToResultsButton";
            this.goToResultsButton.Size = new System.Drawing.Size(126, 78);
            this.goToResultsButton.TabIndex = 14;
            this.goToResultsButton.Text = "Go to Results";
            this.goToResultsButton.UseVisualStyleBackColor = true;
            this.goToResultsButton.Click += new System.EventHandler(this.goToResultsButton_Click);
            // 
            // enableAutoEnrollGPRS
            // 
            this.enableAutoEnrollGPRS.Location = new System.Drawing.Point(736, 86);
            this.enableAutoEnrollGPRS.Name = "enableAutoEnrollGPRS";
            this.enableAutoEnrollGPRS.Size = new System.Drawing.Size(59, 23);
            this.enableAutoEnrollGPRS.TabIndex = 15;
            this.enableAutoEnrollGPRS.Text = "On";
            this.enableAutoEnrollGPRS.UseVisualStyleBackColor = true;
            this.enableAutoEnrollGPRS.Click += new System.EventHandler(this.enableAutoEnrollGPRS_Click);
            // 
            // disableAutoEnrollGPRS
            // 
            this.disableAutoEnrollGPRS.Location = new System.Drawing.Point(801, 86);
            this.disableAutoEnrollGPRS.Name = "disableAutoEnrollGPRS";
            this.disableAutoEnrollGPRS.Size = new System.Drawing.Size(59, 23);
            this.disableAutoEnrollGPRS.TabIndex = 16;
            this.disableAutoEnrollGPRS.Text = "Off";
            this.disableAutoEnrollGPRS.UseVisualStyleBackColor = true;
            this.disableAutoEnrollGPRS.Click += new System.EventHandler(this.disableAutoEnrollGPRS_Click);
            // 
            // enableAutoEnrollBBA
            // 
            this.enableAutoEnrollBBA.Location = new System.Drawing.Point(736, 148);
            this.enableAutoEnrollBBA.Name = "enableAutoEnrollBBA";
            this.enableAutoEnrollBBA.Size = new System.Drawing.Size(59, 23);
            this.enableAutoEnrollBBA.TabIndex = 17;
            this.enableAutoEnrollBBA.Text = "On";
            this.enableAutoEnrollBBA.UseVisualStyleBackColor = true;
            this.enableAutoEnrollBBA.Click += new System.EventHandler(this.enableAutoEnrollBBA_Click);
            // 
            // disableAutoEnrollBBA
            // 
            this.disableAutoEnrollBBA.Location = new System.Drawing.Point(801, 148);
            this.disableAutoEnrollBBA.Name = "disableAutoEnrollBBA";
            this.disableAutoEnrollBBA.Size = new System.Drawing.Size(59, 23);
            this.disableAutoEnrollBBA.TabIndex = 18;
            this.disableAutoEnrollBBA.Text = "Off";
            this.disableAutoEnrollBBA.UseVisualStyleBackColor = true;
            this.disableAutoEnrollBBA.Click += new System.EventHandler(this.disableAutoEnrollBBA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(730, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Auto Enroll GPRS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(736, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Auto Enroll BBA";
            // 
            // EnrollPanelsButton
            // 
            this.EnrollPanelsButton.Location = new System.Drawing.Point(713, 37);
            this.EnrollPanelsButton.Name = "EnrollPanelsButton";
            this.EnrollPanelsButton.Size = new System.Drawing.Size(75, 23);
            this.EnrollPanelsButton.TabIndex = 21;
            this.EnrollPanelsButton.Text = "Add panels";
            this.EnrollPanelsButton.UseVisualStyleBackColor = true;
            this.EnrollPanelsButton.Click += new System.EventHandler(this.EnrollPanelsButton_Click);
            // 
            // RemovePanelsButton
            // 
            this.RemovePanelsButton.Location = new System.Drawing.Point(794, 37);
            this.RemovePanelsButton.Name = "RemovePanelsButton";
            this.RemovePanelsButton.Size = new System.Drawing.Size(90, 23);
            this.RemovePanelsButton.TabIndex = 22;
            this.RemovePanelsButton.Text = "Remove panels";
            this.RemovePanelsButton.UseVisualStyleBackColor = true;
            this.RemovePanelsButton.Click += new System.EventHandler(this.RemovePanelsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 622);
            this.Controls.Add(this.RemovePanelsButton);
            this.Controls.Add(this.EnrollPanelsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disableAutoEnrollBBA);
            this.Controls.Add(this.enableAutoEnrollBBA);
            this.Controls.Add(this.disableAutoEnrollGPRS);
            this.Controls.Add(this.enableAutoEnrollGPRS);
            this.Controls.Add(this.goToResultsButton);
            this.Controls.Add(this.list_States_of_panel_to_set);
            this.Controls.Add(this.list_Types_of_devices_for_enrolling);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.listPanels);
            this.Controls.Add(this.listMethods);
            this.Controls.Add(this.statusLine);
            this.Controls.Add(this.textboxSend);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.textboxRead);
            this.Controls.Add(this.textboxPORT);
            this.Controls.Add(this.textboxIP);
            this.Name = "Form1";
            this.Text = "PowerAPI Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxIP;
        private System.Windows.Forms.TextBox textboxPORT;
        private System.Windows.Forms.TextBox textboxRead;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox textboxSend;
        private System.Windows.Forms.Label statusLine;
        private System.Windows.Forms.ListBox listMethods;
        private System.Windows.Forms.ListBox listPanels;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListBox list_Types_of_devices_for_enrolling;
        private System.Windows.Forms.ListBox list_States_of_panel_to_set;
        private System.Windows.Forms.Button goToResultsButton;
        private System.Windows.Forms.Button enableAutoEnrollGPRS;
        private System.Windows.Forms.Button disableAutoEnrollGPRS;
        private System.Windows.Forms.Button enableAutoEnrollBBA;
        private System.Windows.Forms.Button disableAutoEnrollBBA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EnrollPanelsButton;
        private System.Windows.Forms.Button RemovePanelsButton;
    }
}


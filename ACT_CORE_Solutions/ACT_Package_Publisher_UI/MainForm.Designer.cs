namespace ACT_Package_Publisher_UI
{
    partial class MainForm
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
            this.Library_LlistBox = new System.Windows.Forms.ListBox();
            this.PublicationFile_listBox = new System.Windows.Forms.ListBox();
            this.NuGetServers = new System.Windows.Forms.CheckedListBox();
            this.PublishButton = new System.Windows.Forms.Button();
            this.Results = new System.Windows.Forms.TextBox();
            this.SelectedFiles_listBox = new System.Windows.Forms.ListBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Library_LlistBox
            // 
            this.Library_LlistBox.FormattingEnabled = true;
            this.Library_LlistBox.ItemHeight = 25;
            this.Library_LlistBox.Location = new System.Drawing.Point(12, 59);
            this.Library_LlistBox.Name = "Library_LlistBox";
            this.Library_LlistBox.Size = new System.Drawing.Size(393, 229);
            this.Library_LlistBox.TabIndex = 0;
            this.Library_LlistBox.SelectedIndexChanged += new System.EventHandler(this.Library_LlistBox_SelectedIndexChanged);
            // 
            // PublicationFile_listBox
            // 
            this.PublicationFile_listBox.FormattingEnabled = true;
            this.PublicationFile_listBox.ItemHeight = 25;
            this.PublicationFile_listBox.Location = new System.Drawing.Point(411, 59);
            this.PublicationFile_listBox.Name = "PublicationFile_listBox";
            this.PublicationFile_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PublicationFile_listBox.Size = new System.Drawing.Size(393, 229);
            this.PublicationFile_listBox.TabIndex = 1;
            this.PublicationFile_listBox.SelectedIndexChanged += new System.EventHandler(this.PublicationFile_listBox_SelectedIndexChanged);
            // 
            // NuGetServers
            // 
            this.NuGetServers.FormattingEnabled = true;
            this.NuGetServers.Items.AddRange(new object[] {
            "http://actnuget.homeunix.com:5555/v3/index.json ###PACKAGE###"});
            this.NuGetServers.Location = new System.Drawing.Point(12, 294);
            this.NuGetServers.Name = "NuGetServers";
            this.NuGetServers.Size = new System.Drawing.Size(916, 144);
            this.NuGetServers.TabIndex = 2;
            // 
            // PublishButton
            // 
            this.PublishButton.Location = new System.Drawing.Point(934, 294);
            this.PublishButton.Name = "PublishButton";
            this.PublishButton.Size = new System.Drawing.Size(269, 144);
            this.PublishButton.TabIndex = 3;
            this.PublishButton.Text = "Publish";
            this.PublishButton.UseVisualStyleBackColor = true;
            this.PublishButton.Click += new System.EventHandler(this.PublishButton_Click);
            // 
            // Results
            // 
            this.Results.Location = new System.Drawing.Point(12, 444);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(1191, 231);
            this.Results.TabIndex = 4;
            // 
            // SelectedFiles_listBox
            // 
            this.SelectedFiles_listBox.FormattingEnabled = true;
            this.SelectedFiles_listBox.ItemHeight = 25;
            this.SelectedFiles_listBox.Location = new System.Drawing.Point(810, 59);
            this.SelectedFiles_listBox.Name = "SelectedFiles_listBox";
            this.SelectedFiles_listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.SelectedFiles_listBox.Size = new System.Drawing.Size(393, 229);
            this.SelectedFiles_listBox.TabIndex = 5;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(12, 12);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(142, 41);
            this.RefreshBtn.TabIndex = 6;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 687);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.SelectedFiles_listBox);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.PublishButton);
            this.Controls.Add(this.NuGetServers);
            this.Controls.Add(this.PublicationFile_listBox);
            this.Controls.Add(this.Library_LlistBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Package Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox Library_LlistBox;
        private ListBox PublicationFile_listBox;
        private CheckedListBox NuGetServers;
        private Button PublishButton;
        private TextBox Results;
        private ListBox SelectedFiles_listBox;
        private Button RefreshBtn;
    }
}
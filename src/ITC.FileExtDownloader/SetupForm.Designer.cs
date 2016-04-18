namespace ITC.FileExtDownloader
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.listBoxExts = new System.Windows.Forms.ListBox();
            this.textBoxNewExt = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxExts
            // 
            this.listBoxExts.FormattingEnabled = true;
            this.listBoxExts.Location = new System.Drawing.Point(13, 39);
            this.listBoxExts.Name = "listBoxExts";
            this.listBoxExts.Size = new System.Drawing.Size(88, 186);
            this.listBoxExts.TabIndex = 0;
            // 
            // textBoxNewExt
            // 
            this.textBoxNewExt.Location = new System.Drawing.Point(13, 13);
            this.textBoxNewExt.Name = "textBoxNewExt";
            this.textBoxNewExt.Size = new System.Drawing.Size(88, 20);
            this.textBoxNewExt.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(108, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 235);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxNewExt);
            this.Controls.Add(this.listBoxExts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxExts;
        private System.Windows.Forms.TextBox textBoxNewExt;
        private System.Windows.Forms.Button buttonAdd;
    }
}


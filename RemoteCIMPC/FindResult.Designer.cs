namespace RemoteCIMPC
{
    partial class FindBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindBox));
            this.findValue = new System.Windows.Forms.TextBox();
            this.find_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.showResult = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // findValue
            // 
            this.findValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findValue.Location = new System.Drawing.Point(7, 8);
            this.findValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.findValue.Name = "findValue";
            this.findValue.Size = new System.Drawing.Size(364, 27);
            this.findValue.TabIndex = 0;
            this.findValue.TextChanged += new System.EventHandler(this.findValue_TextChanged);
            this.findValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.findValue_Press);
            // 
            // find_btn
            // 
            this.find_btn.Location = new System.Drawing.Point(16, 40);
            this.find_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(156, 29);
            this.find_btn.TabIndex = 2;
            this.find_btn.Text = "Find";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(199, 40);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(156, 29);
            this.close_btn.TabIndex = 3;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // showResult
            // 
            this.showResult.Location = new System.Drawing.Point(7, 76);
            this.showResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showResult.Name = "showResult";
            this.showResult.Size = new System.Drawing.Size(364, 244);
            this.showResult.TabIndex = 4;
            this.showResult.UseCompatibleStateImageBehavior = false;
            this.showResult.View = System.Windows.Forms.View.List;
            this.showResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.showResult_MouseDoubleClick);
            // 
            // FindBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 326);
            this.Controls.Add(this.showResult);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.findValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindBox";
            this.Text = "FindBox";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindBox_FormClosed);
            this.Load += new System.EventHandler(this.FindBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox findValue;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ListView showResult;
    }
}
using System;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    partial class DataChanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataChanger));
            this.shop_box = new System.Windows.Forms.ComboBox();
            this.eqip_box = new System.Windows.Forms.TextBox();
            this.shop_label = new System.Windows.Forms.Label();
            this.eqid_label = new System.Windows.Forms.Label();
            this.eqip_label = new System.Windows.Forms.Label();
            this.left_btn = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.eqid_box = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // shop_box
            // 
            this.shop_box.FormattingEnabled = true;
            this.shop_box.Location = new System.Drawing.Point(155, 15);
            this.shop_box.Margin = new System.Windows.Forms.Padding(4);
            this.shop_box.Name = "shop_box";
            this.shop_box.Size = new System.Drawing.Size(160, 23);
            this.shop_box.TabIndex = 9;
            // 
            // eqip_box
            // 
            this.eqip_box.Location = new System.Drawing.Point(155, 112);
            this.eqip_box.Margin = new System.Windows.Forms.Padding(4);
            this.eqip_box.Name = "eqip_box";
            this.eqip_box.Size = new System.Drawing.Size(160, 25);
            this.eqip_box.TabIndex = 2;
            // 
            // shop_label
            // 
            this.shop_label.AutoSize = true;
            this.shop_label.Location = new System.Drawing.Point(44, 19);
            this.shop_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shop_label.Name = "shop_label";
            this.shop_label.Size = new System.Drawing.Size(87, 15);
            this.shop_label.TabIndex = 3;
            this.shop_label.Text = "Shop Name:";
            // 
            // eqid_label
            // 
            this.eqid_label.AutoSize = true;
            this.eqid_label.Location = new System.Drawing.Point(44, 66);
            this.eqid_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eqid_label.Name = "eqid_label";
            this.eqid_label.Size = new System.Drawing.Size(55, 15);
            this.eqid_label.TabIndex = 4;
            this.eqid_label.Text = "EQ ID:";
            // 
            // eqip_label
            // 
            this.eqip_label.AutoSize = true;
            this.eqip_label.Location = new System.Drawing.Point(44, 116);
            this.eqip_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eqip_label.Name = "eqip_label";
            this.eqip_label.Size = new System.Drawing.Size(55, 15);
            this.eqip_label.TabIndex = 5;
            this.eqip_label.Text = "EQ IP:";
            // 
            // left_btn
            // 
            this.left_btn.Location = new System.Drawing.Point(27, 191);
            this.left_btn.Margin = new System.Windows.Forms.Padding(4);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(100, 29);
            this.left_btn.TabIndex = 6;
            this.left_btn.Text = "Left_btn";
            this.left_btn.UseVisualStyleBackColor = true;
            this.left_btn.Click += new System.EventHandler(this.left_btn_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(259, 191);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 29);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // eqid_box
            // 
            this.eqid_box.FormattingEnabled = true;
            this.eqid_box.Location = new System.Drawing.Point(155, 62);
            this.eqid_box.Margin = new System.Windows.Forms.Padding(4);
            this.eqid_box.Name = "eqid_box";
            this.eqid_box.Size = new System.Drawing.Size(160, 23);
            this.eqid_box.TabIndex = 10;
            // 
            // DataChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 236);
            this.Controls.Add(this.eqid_box);
            this.Controls.Add(this.shop_box);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.eqip_label);
            this.Controls.Add(this.eqid_label);
            this.Controls.Add(this.shop_label);
            this.Controls.Add(this.eqip_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataChanger";
            this.Text = "DataChanger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataChanger_FormClosed);
            this.Load += new System.EventHandler(this.DataChanger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox shop_box;
        private System.Windows.Forms.ComboBox eqid_box;
        private System.Windows.Forms.TextBox eqip_box;
        private System.Windows.Forms.Label shop_label;
        private System.Windows.Forms.Label eqid_label;
        private System.Windows.Forms.Label eqip_label;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button Cancel;

    }
}
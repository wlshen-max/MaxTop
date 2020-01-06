using System;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    partial class Remote
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NetDrive = new System.Windows.Forms.RadioButton();
            this.RemotePC = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Select_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Refresh_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Exit_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoErrorLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(2, 57);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(280, 395);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(164, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox1_Press);
            // 
            // NetDrive
            // 
            this.NetDrive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NetDrive.AutoSize = true;
            this.NetDrive.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NetDrive.FlatAppearance.CheckedBackColor = System.Drawing.Color.Blue;
            this.NetDrive.Location = new System.Drawing.Point(85, 32);
            this.NetDrive.Name = "NetDrive";
            this.NetDrive.Size = new System.Drawing.Size(77, 16);
            this.NetDrive.TabIndex = 2;
            this.NetDrive.Text = "Net Drive";
            this.NetDrive.UseVisualStyleBackColor = true;
            // 
            // RemotePC
            // 
            this.RemotePC.AutoSize = true;
            this.RemotePC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RemotePC.Location = new System.Drawing.Point(5, 32);
            this.RemotePC.Name = "RemotePC";
            this.RemotePC.Size = new System.Drawing.Size(77, 16);
            this.RemotePC.TabIndex = 1;
            this.RemotePC.Text = "Remote PC";
            this.RemotePC.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Select_btn,
            this.menu_Refresh_btn,
            this.menu_Exit_btn});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(53, 21);
            this.Menu.Text = "Menu";
            // 
            // menu_Select_btn
            // 
            this.menu_Select_btn.Name = "menu_Select_btn";
            this.menu_Select_btn.Size = new System.Drawing.Size(189, 22);
            this.menu_Select_btn.Text = "Select           Ctrl+F";
            this.menu_Select_btn.Click += new System.EventHandler(this.menu_Select_btn_Click);
            // 
            // menu_Refresh_btn
            // 
            this.menu_Refresh_btn.Name = "menu_Refresh_btn";
            this.menu_Refresh_btn.Size = new System.Drawing.Size(189, 22);
            this.menu_Refresh_btn.Text = "Refresh              F5";
            this.menu_Refresh_btn.Click += new System.EventHandler(this.menu_Refresh_btn_Click);
            // 
            // menu_Exit_btn
            // 
            this.menu_Exit_btn.Name = "menu_Exit_btn";
            this.menu_Exit_btn.Size = new System.Drawing.Size(189, 22);
            this.menu_Exit_btn.Text = "Exit              Alt+F4";
            this.menu_Exit_btn.Click += new System.EventHandler(this.menu_Exit_btn_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.Modify,
            this.Delete});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // Create
            // 
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(117, 22);
            this.Create.Text = "Create";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Modify
            // 
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(117, 22);
            this.Modify.Text = "Modify";
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(117, 22);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.aboutToolStripMenuItem.Text = "Helper";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem1.Text = "TBD";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteToolStripMenuItem,
            this.netDriveToolStripMenuItem,
            this.appVersionToolStripMenuItem,
            this.gotoErrorLogToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 114);
            // 
            // remoteToolStripMenuItem
            // 
            this.remoteToolStripMenuItem.Name = "remoteToolStripMenuItem";
            this.remoteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.remoteToolStripMenuItem.Text = "Remote";
            this.remoteToolStripMenuItem.Click += new System.EventHandler(this.remoteToolStripMenuItem_Click);
            // 
            // netDriveToolStripMenuItem
            // 
            this.netDriveToolStripMenuItem.Name = "netDriveToolStripMenuItem";
            this.netDriveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.netDriveToolStripMenuItem.Text = "NetDrive";
            this.netDriveToolStripMenuItem.Click += new System.EventHandler(this.netDriveToolStripMenuItem_Click);
            // 
            // appVersionToolStripMenuItem
            // 
            this.appVersionToolStripMenuItem.Name = "appVersionToolStripMenuItem";
            this.appVersionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.appVersionToolStripMenuItem.Text = "App Version";
            this.appVersionToolStripMenuItem.Click += new System.EventHandler(this.appVersionToolStripMenuItem_Click);
            // 
            // gotoErrorLogToolStripMenuItem
            // 
            this.gotoErrorLogToolStripMenuItem.Name = "gotoErrorLogToolStripMenuItem";
            this.gotoErrorLogToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.gotoErrorLogToolStripMenuItem.Text = "Goto ErrorLog";
            this.gotoErrorLogToolStripMenuItem.Click += new System.EventHandler(this.gotoErrorLogToolStripMenuItem_Click);
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 454);
            this.Controls.Add(this.RemotePC);
            this.Controls.Add(this.NetDrive);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Remote";
            this.Text = "RemoteCIMPC";
            this.Load += new System.EventHandler(this.Remote_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Remote_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private RadioButton NetDrive;
        private RadioButton RemotePC;
        private MenuStrip menuStrip1;
        private new ToolStripMenuItem Menu;
        private ToolStripMenuItem menu_Select_btn;
        private ToolStripMenuItem menu_Refresh_btn;
        private ToolStripMenuItem menu_Exit_btn;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem Create;
        private ToolStripMenuItem Modify;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem Delete;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem remoteToolStripMenuItem;
        private ToolStripMenuItem netDriveToolStripMenuItem;
        private ToolStripMenuItem appVersionToolStripMenuItem;
        private ToolStripMenuItem gotoErrorLogToolStripMenuItem;
    }
}


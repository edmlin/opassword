/*
 * Created by SharpDevelop.
 * User: YLIN68
 * Date: 12/10/2015
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace opassword
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbNewPassword;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbSelectAll;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Button btChange;
		private System.Windows.Forms.Button btCheck;
		private System.Windows.Forms.TextBox tbUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nThreads;
		private System.Windows.Forms.Button btNewPassword;
		private System.Windows.Forms.Button btPassword;
		private System.Windows.Forms.Button btUser;
		private System.Windows.Forms.Button btNext;
		private System.Windows.Forms.Button btPrev;
		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ContextMenuStrip cmDelete;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.Button btReload;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btReload = new System.Windows.Forms.Button();
			this.btNext = new System.Windows.Forms.Button();
			this.btPrev = new System.Windows.Forms.Button();
			this.tbFind = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btUser = new System.Windows.Forms.Button();
			this.btNewPassword = new System.Windows.Forms.Button();
			this.btPassword = new System.Windows.Forms.Button();
			this.tbUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbNewPassword = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbSelectAll = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.nThreads = new System.Windows.Forms.NumericUpDown();
			this.btClose = new System.Windows.Forms.Button();
			this.btChange = new System.Windows.Forms.Button();
			this.btCheck = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.cmDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nThreads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.cmDelete.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btReload);
			this.panel1.Controls.Add(this.btNext);
			this.panel1.Controls.Add(this.btPrev);
			this.panel1.Controls.Add(this.tbFind);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.btUser);
			this.panel1.Controls.Add(this.btNewPassword);
			this.panel1.Controls.Add(this.btPassword);
			this.panel1.Controls.Add(this.tbUser);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbNewPassword);
			this.panel1.Controls.Add(this.tbPassword);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbSelectAll);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(868, 67);
			this.panel1.TabIndex = 0;
			// 
			// btReload
			// 
			this.btReload.Location = new System.Drawing.Point(376, 8);
			this.btReload.Name = "btReload";
			this.btReload.Size = new System.Drawing.Size(100, 23);
			this.btReload.TabIndex = 11;
			this.btReload.TabStop = false;
			this.btReload.Text = "Reload Servers";
			this.btReload.UseVisualStyleBackColor = true;
			this.btReload.Click += new System.EventHandler(this.BtReloadClick);
			// 
			// btNext
			// 
			this.btNext.Location = new System.Drawing.Point(283, 9);
			this.btNext.Name = "btNext";
			this.btNext.Size = new System.Drawing.Size(24, 23);
			this.btNext.TabIndex = 10;
			this.btNext.Text = ">";
			this.btNext.UseVisualStyleBackColor = true;
			this.btNext.Click += new System.EventHandler(this.BtNextClick);
			// 
			// btPrev
			// 
			this.btPrev.Location = new System.Drawing.Point(253, 9);
			this.btPrev.Name = "btPrev";
			this.btPrev.Size = new System.Drawing.Size(24, 23);
			this.btPrev.TabIndex = 9;
			this.btPrev.Text = "<";
			this.btPrev.UseVisualStyleBackColor = true;
			this.btPrev.Click += new System.EventHandler(this.BtPrevClick);
			// 
			// tbFind
			// 
			this.tbFind.Location = new System.Drawing.Point(147, 11);
			this.tbFind.Name = "tbFind";
			this.tbFind.Size = new System.Drawing.Size(100, 20);
			this.tbFind.TabIndex = 8;
			this.tbFind.TextChanged += new System.EventHandler(this.TbFindTextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(119, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "Find:";
			// 
			// btUser
			// 
			this.btUser.Location = new System.Drawing.Point(129, 36);
			this.btUser.Name = "btUser";
			this.btUser.Size = new System.Drawing.Size(23, 23);
			this.btUser.TabIndex = 2;
			this.btUser.Text = "↓";
			this.btUser.UseVisualStyleBackColor = true;
			this.btUser.Click += new System.EventHandler(this.BtUserClick);
			// 
			// btNewPassword
			// 
			this.btNewPassword.Location = new System.Drawing.Point(552, 36);
			this.btNewPassword.Name = "btNewPassword";
			this.btNewPassword.Size = new System.Drawing.Size(23, 23);
			this.btNewPassword.TabIndex = 6;
			this.btNewPassword.Text = "↓";
			this.btNewPassword.UseVisualStyleBackColor = true;
			this.btNewPassword.Click += new System.EventHandler(this.BtNewPasswordClick);
			// 
			// btPassword
			// 
			this.btPassword.Location = new System.Drawing.Point(325, 36);
			this.btPassword.Name = "btPassword";
			this.btPassword.Size = new System.Drawing.Size(23, 23);
			this.btPassword.TabIndex = 4;
			this.btPassword.Text = "↓";
			this.btPassword.UseVisualStyleBackColor = true;
			this.btPassword.Click += new System.EventHandler(this.BtPasswordClick);
			// 
			// tbUser
			// 
			this.tbUser.Location = new System.Drawing.Point(40, 38);
			this.tbUser.Name = "tbUser";
			this.tbUser.Size = new System.Drawing.Size(83, 20);
			this.tbUser.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "User:";
			// 
			// tbNewPassword
			// 
			this.tbNewPassword.Location = new System.Drawing.Point(460, 39);
			this.tbNewPassword.Name = "tbNewPassword";
			this.tbNewPassword.Size = new System.Drawing.Size(86, 20);
			this.tbNewPassword.TabIndex = 5;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(231, 38);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(88, 20);
			this.tbPassword.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(376, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "New Password:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(170, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 21);
			this.label1.TabIndex = 1;
			this.label1.Text = "Password:";
			// 
			// cbSelectAll
			// 
			this.cbSelectAll.Location = new System.Drawing.Point(12, 11);
			this.cbSelectAll.Name = "cbSelectAll";
			this.cbSelectAll.Size = new System.Drawing.Size(104, 24);
			this.cbSelectAll.TabIndex = 0;
			this.cbSelectAll.Text = "Select All";
			this.cbSelectAll.UseVisualStyleBackColor = true;
			this.cbSelectAll.Click += new System.EventHandler(this.CbSelectAllClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.nThreads);
			this.panel2.Controls.Add(this.btClose);
			this.panel2.Controls.Add(this.btChange);
			this.panel2.Controls.Add(this.btCheck);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 384);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(868, 49);
			this.panel2.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 19);
			this.label4.TabIndex = 4;
			this.label4.Text = "Threads:";
			// 
			// nThreads
			// 
			this.nThreads.Location = new System.Drawing.Point(69, 16);
			this.nThreads.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.nThreads.Name = "nThreads";
			this.nThreads.Size = new System.Drawing.Size(59, 20);
			this.nThreads.TabIndex = 3;
			this.nThreads.Value = new decimal(new int[] {
			5,
			0,
			0,
			0});
			// 
			// btClose
			// 
			this.btClose.Location = new System.Drawing.Point(510, 14);
			this.btClose.Name = "btClose";
			this.btClose.Size = new System.Drawing.Size(75, 23);
			this.btClose.TabIndex = 2;
			this.btClose.Text = "Close";
			this.btClose.UseVisualStyleBackColor = true;
			this.btClose.Click += new System.EventHandler(this.BtCloseClick);
			// 
			// btChange
			// 
			this.btChange.Location = new System.Drawing.Point(385, 14);
			this.btChange.Name = "btChange";
			this.btChange.Size = new System.Drawing.Size(75, 23);
			this.btChange.TabIndex = 1;
			this.btChange.Text = "Change";
			this.btChange.UseVisualStyleBackColor = true;
			this.btChange.Click += new System.EventHandler(this.btChangeClick);
			// 
			// btCheck
			// 
			this.btCheck.Location = new System.Drawing.Point(259, 14);
			this.btCheck.Name = "btCheck";
			this.btCheck.Size = new System.Drawing.Size(75, 23);
			this.btCheck.TabIndex = 0;
			this.btCheck.Text = "Check";
			this.btCheck.UseVisualStyleBackColor = true;
			this.btCheck.Click += new System.EventHandler(this.btCheckClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.cmDelete;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 67);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(868, 317);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.DataSourceChanged += new System.EventHandler(this.DataGridView1DataSourceChanged);
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView1CellFormatting);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridView1CurrentCellDirtyStateChanged);
			this.dataGridView1.Sorted += new System.EventHandler(this.DataGridView1Sorted);
			// 
			// cmDelete
			// 
			this.cmDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.deleteToolStripMenuItem});
			this.cmDelete.Name = "cmDelete";
			this.cmDelete.Size = new System.Drawing.Size(108, 26);
			this.cmDelete.Opening += new System.ComponentModel.CancelEventHandler(this.CmDeleteOpening);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(868, 433);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "opassword";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nThreads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.cmDelete.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}

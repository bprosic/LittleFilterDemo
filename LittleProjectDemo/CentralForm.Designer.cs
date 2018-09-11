/*
 * Created by SharpDevelop.
 * User: Elektrolit
 * Date: 11.9.2018.
 * Time: 9:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LittleProjectDemo
{
	partial class CentralForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnOpenDialog;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIndexi;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFilePath;
		private System.Windows.Forms.Button btnStopGenerate;
		
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
			this.btnOpenDialog = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIndexi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFilePath = new System.Windows.Forms.TextBox();
			this.btnStopGenerate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOpenDialog
			// 
			this.btnOpenDialog.Location = new System.Drawing.Point(578, 3);
			this.btnOpenDialog.Name = "btnOpenDialog";
			this.btnOpenDialog.Size = new System.Drawing.Size(75, 23);
			this.btnOpenDialog.TabIndex = 27;
			this.btnOpenDialog.Text = "Open";
			this.btnOpenDialog.UseVisualStyleBackColor = true;
			this.btnOpenDialog.Click += new System.EventHandler(this.BtnOpenDialog_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(99, 66);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 26;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.Location = new System.Drawing.Point(237, 71);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(405, 18);
			this.lblStatus.TabIndex = 25;
			this.lblStatus.Text = "Status:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(200, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 18);
			this.label3.TabIndex = 24;
			this.label3.Text = "Status:";
			// 
			// txtIndexi
			// 
			this.txtIndexi.Location = new System.Drawing.Point(99, 28);
			this.txtIndexi.Name = "txtIndexi";
			this.txtIndexi.Size = new System.Drawing.Size(45, 20);
			this.txtIndexi.TabIndex = 23;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 22);
			this.label2.TabIndex = 22;
			this.label2.Text = "Wieviel indexes:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 22);
			this.label1.TabIndex = 21;
			this.label1.Text = "Datei:";
			// 
			// txtFilePath
			// 
			this.txtFilePath.AllowDrop = true;
			this.txtFilePath.Location = new System.Drawing.Point(99, 6);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Size = new System.Drawing.Size(473, 20);
			this.txtFilePath.TabIndex = 20;
			this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtBoxPath_DragDrop);
			this.txtFilePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtBoxPath_DragEnter);
			this.txtFilePath.DragOver += new System.Windows.Forms.DragEventHandler(this.txtBoxPath_DragOver);
			// 
			// btnStopGenerate
			// 
			this.btnStopGenerate.Location = new System.Drawing.Point(99, 66);
			this.btnStopGenerate.Name = "btnStopGenerate";
			this.btnStopGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnStopGenerate.TabIndex = 28;
			this.btnStopGenerate.Text = "Stop";
			this.btnStopGenerate.UseVisualStyleBackColor = true;
			this.btnStopGenerate.Click += new System.EventHandler(this.BtnStopGenerate_Click);
			// 
			// CentralForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 102);
			this.Controls.Add(this.btnOpenDialog);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtIndexi);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFilePath);
			this.Controls.Add(this.btnStopGenerate);
			this.Controls.Add(this.btnGenerate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "CentralForm";
			this.ShowIcon = false;
			this.Text = "CentralForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CentralFormFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

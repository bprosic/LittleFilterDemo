/*
 * Created by SharpDevelop.
 * User: Elektrolit
 * Date: 11.9.2018.
 * Time: 9:19
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LittleProjectDemo
{
	/// <summary>
	/// Main program
	/// </summary>
	public partial class CentralForm : Form
	{
		public CentralForm()
		{
			// Global Vars = Classes + BackgroundWorker. Is this good alternative for using vars as global vars?
			// Global Variables sind im ParametersClass
			
			InitializeComponent();
			//for user feedback
			initBWGenerateFile ();
			//hide status label and stop button
			hideStatus_StopControls (false);
			//init classes
			InitLittleProjectDemoClass ();
		}
		#region ENGINE
		#region INIT CLASSES
		void InitLittleProjectDemoClass ()
		{
			//ist diese mit GLOBABL vars auch schlecht?
			ParametersClass.Tc = new LittleProjectDemoClass ();
			ParametersClass.Tcf = new LittleProjectDemoClassFunctions ();
		}
		#endregion
		
		#region PROCESS THE List
		void generateNew(string filePath, string fileName, int howManyRowsToFilter, DoWorkEventArgs e)
		{
			// how to calculate percentage for backgroundworker when I have several methods 
			// z.B. -open file class (while reading a file) and generate new file??
			Int32 counterHowManyProcessedLines = 0;
			ParametersClass.CountTotalRowsInFile = ParametersClass.Tcf.LittleProjectDemoList.Count;
			
			// here i skipped order by desc and took "howmanyrowstofilter" rows
			// this linq is magic :)
			var grupDesc = ParametersClass.Tcf.LittleProjectDemoList
				.GroupBy(u => u.IdNr)
            	.Select(grp => grp.Skip(Math.Max(0, grp.Count() - howManyRowsToFilter)).ToList())
            	.ToList();
			
			using (var output = new StreamWriter(Path.Combine(filePath, "filter_" + fileName), false, Encoding.Default)) {
				output.WriteLine(ParametersClass.HeaderRowCsv);
				var someLine = new StringBuilder();
				
				//is there a way without using two foreach loops??
				
				foreach (var c in grupDesc) {
					/*this "if stmt" and "percent calculation" slows down the code!*/
					if (ParametersClass.BwGenerate.CancellationPending) {
						e.Cancel = true;
						ParametersClass.BwGenerate.ReportProgress(0);
						ParametersClass.log.Info("Work canceled by user");
						return;
					}
					
					foreach (LittleProjectDemoClass cd in c) {
						//to calc percentage of bw
						counterHowManyProcessedLines += 1;
						
						someLine.AppendLine(cd.IdNr + ";" +
						cd.IdNrIndex + ";" +
						cd.Name + ";" +
						cd.SomeNumbers + ";" +
						cd.SomeNumbers1 + ";" +
						cd.SomeNumbers2 + ";" +
						cd.SomeNumbers3 + ";" +
						cd.Sn4 + ";" +
						cd.Sn5 + ";" +
						cd.Sn6 + ";" +
						cd.Sn7 + ";" +
						cd.Sn8 + ";" +
						cd.Sn9 + ";" +
						cd.Sn10 + ";" +
						cd.Sn11 + ";" +
						cd.Sn12 + ";" +
						cd.Sn13 + ";" +
						cd.Sn14 + ";" +
						cd.Sn15 + ";" +
						cd.Sn16 + ";" +
						cd.Sn17 + ";" +
						cd.Sn18 + ";" +
						cd.Sn19 + ";" +
						cd.Sn20 + ";" +
						cd.Sn21 + ";" +
						cd.Sn22 + ";" +
						cd.Sn23 + ";" +
						cd.Sn24 + ";" +
						cd.Sn25 + ";" +
						cd.Sn26 + ";" +
						cd.Sn27);
						//send percent
						ParametersClass.BwCounterPercent = (int)(((100f * counterHowManyProcessedLines) / ParametersClass.CountTotalRowsInFile));
						ParametersClass.BwGenerate.ReportProgress(ParametersClass.BwCounterPercent);
					}
				}
				output.WriteLine(someLine);
			}
		}
		#endregion
		#endregion
		
		#region FORM CONTROLS MANIPULATION
		
		#region DISABLE ALL CONTROLS
		void disableControls(bool setTrueToDisable)
		{
			//happy debugging :)
			txtFilePath.Enabled = !setTrueToDisable;
			txtIndexi.Enabled = !setTrueToDisable;
			btnOpenDialog.Enabled = !setTrueToDisable;

			if (btnGenerate.Visible == setTrueToDisable)
				btnGenerate.Visible = !setTrueToDisable;
			else
				btnGenerate.Visible = setTrueToDisable;
			
			if (btnStopGenerate.Visible == !setTrueToDisable)
				btnStopGenerate.Visible = setTrueToDisable;
			else
				btnStopGenerate.Visible = !setTrueToDisable;
			
		}
		#endregion
		
		#region HIDE STATUS AND STOP CONTROLS
		void hideStatus_StopControls (bool setFalseToHide)
		{
			lblStatus.Visible = setFalseToHide;
			btnStopGenerate.Visible = setFalseToHide;
		}
		#endregion
		
		#region STATUS MESSAGES
		void statusMsg(string msg, Color farbe)
		{
			//for user feedback
			lblStatus.Text = msg;
			lblStatus.ForeColor = farbe;
			lblStatus.Visible = true;
		}
		#endregion
		
		#endregion

		#region FORM CONTROL EVENTS
		
		#region BTN GENERATE CLICK
		void btnGenerate_Click(object sender, EventArgs e)
		{
			//generate file path from textbox
			var path = txtFilePath.Text;
			if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path)) {
				statusMsg("Bitte, enter Datei Path...", Color.Red);
				return;
			}
			
			if (!string.IsNullOrEmpty(path)) {
				//diese ist die Frage - ist filename path richtig oder nein
				//assuming this file is on windows system
				//funktioniert nur mit NTFS und FAT16/32, exFAT oder andere filesys (kernel) nein
				if (!File.Exists(path)) {
					statusMsg("Falsch datei path", Color.Red);
					return;
				}
			}
			
			var p = path.LastIndexOf(@"\");
			ParametersClass.FilePath = path.Substring(0, p);
			ParametersClass.FileName = path.Remove(0, p + 1);
			var indexes = 0;
			
			if (txtIndexi.Text.Equals("") && string.IsNullOrEmpty(txtIndexi.Text))
				ParametersClass.ArtIndexNum = indexes;
			else if (!int.TryParse(txtIndexi.Text, out indexes) || indexes < 0) {
				statusMsg("Nür positiv Nummer", Color.OrangeRed);
				ParametersClass.log.Info("entered wrong number: " + txtIndexi.Text);
				return;
			} else
				ParametersClass.ArtIndexNum = indexes;
			
			//ParametersClass.log.Info ("index ist "+ParametersClass.ArtIndexNum);
			
			//set textbox to readonly and hide some buttons
			disableControls(true);
			//run bw generate file
			ParametersClass.BwGenerate.RunWorkerAsync();
		}
		#endregion
		
		#region TXTBOX PATH DragDrop
		void txtBoxPath_DragDrop (object s, DragEventArgs e)
		{
			if (e.Data.GetDataPresent (DataFormats.FileDrop, false) == true) 
				e.Effect = DragDropEffects.All;
		}
		#endregion
		
		#region TXTBOX PATH DragEnter
		void txtBoxPath_DragEnter (object s, DragEventArgs e)
		{
			var filePath = (string[])e.Data.GetData (DataFormats.FileDrop);
			if(filePath!=null && filePath.Length!=0)
				txtFilePath.Text=filePath[0];
		}
		#endregion
		
		#region TXTBOX PATH DragOver
		void txtBoxPath_DragOver (object s, DragEventArgs e)
		{
			if (e.Data.GetDataPresent (DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}
		#endregion
		
		#region BTN STOP GENERATE
		void BtnStopGenerate_Click(object s, EventArgs e)
		{
			stopBwGenerate();
		}
		#endregion
		
		#region INIT BACKGROUNDWORKER FOR GENERATE NEW FILE
		void initBWGenerateFile ()
		{
			//user feedback
			ParametersClass.BwGenerate = new BackgroundWorker();
			ParametersClass.BwGenerate.DoWork += bwGenerate_LoadData;
			ParametersClass.BwGenerate.ProgressChanged += bwGenerate_ProgressChanged;
			ParametersClass.BwGenerate.RunWorkerCompleted += bwGenerate_WorkerCompleted;
			ParametersClass.BwGenerate.WorkerReportsProgress = true;
			ParametersClass.BwGenerate.WorkerSupportsCancellation = true;
		}
		#endregion
		
		#region FORM CLOSING EVENT
		void CentralFormFormClosing (object sender, FormClosingEventArgs e)
		{
			stopBwGenerate ();
		}
		#endregion
		
		#region BTN OPEN DIALOG
		void BtnOpenDialog_Click(object sender, EventArgs e)
		{
			var od = new OpenFileDialog();
			
			if (!string.IsNullOrEmpty(txtFilePath.Text) && !string.IsNullOrWhiteSpace(txtFilePath.Text))
				od.InitialDirectory = @txtFilePath.Text;
			else
				od.InitialDirectory = @"C:\";			
			
			od.RestoreDirectory = false;
			od.CheckFileExists = true;
			od.CheckPathExists = true;
			
			if(od.ShowDialog()==DialogResult.OK)
				txtFilePath.Text = od.FileName;
			
		}
		#endregion
		
		#endregion
		
		#region BACKGROUND WORKER: Generate File
		
		#region bw Generate File - work completed
		void bwGenerate_WorkerCompleted(object s, RunWorkerCompletedEventArgs e)
		{
			//display result and here you can mess with GUI
			if (e.Cancelled) 
				statusMsg ("Something went wrong", Color.Red);
			// Check to see if an error occurred in the background process.
			else if (e.Error != null) 
				statusMsg ("Some error occured during process! Read log info.", Color.Red);
			else 
				statusMsg ("Finished with " + ParametersClass.FileName + "!", Color.LimeGreen);

			//Change the status of the buttons on the UI accordingly
			disableControls(false);
			
		}
		#endregion
		
		#region bw Generate File - process data
		void bwGenerate_LoadData(object sender, DoWorkEventArgs e)
		{
			//dont mess with GUI here
			//this is for calculation progress..set to 0
			ParametersClass.BwCounterPercent = 0;
			
			var watch = new Stopwatch();
			watch.Start();
			
			//if btn stop is pressed, send flag to bw in order to stop
			if (ParametersClass.BwGenerate.CancellationPending) {
				e.Cancel = true;
				ParametersClass.BwGenerate.ReportProgress(0);
				ParametersClass.log.Info("Work canceled by user");
				return;
			}
			
			//process the file
			ParametersClass.Tcf.LittleProjectDemoList = new List<LittleProjectDemoClass>();
			//store info to a new list
			var of = OpenFile.boolOpenFile(ParametersClass.FilePath, "\\" + ParametersClass.FileName, ParametersClass.Tcf.LittleProjectDemoList);
			if (!of) 
				e.Cancel = true;
			
			//process list
			generateNew(ParametersClass.FilePath, ParametersClass.FileName, ParametersClass.ArtIndexNum, e);
			
			watch.Stop();
			TimeSpan ts = watch.Elapsed;
			var elapsedTime = ts.TotalMilliseconds.ToString();
			var elSec = ts.TotalSeconds.ToString();
			
			var infoMeasurement = new StringBuilder();
			infoMeasurement.AppendLine("this is measurement for how much indexes: " + ParametersClass.ArtIndexNum);
			infoMeasurement.AppendLine("time of execution: " + elapsedTime + " miliseconds");
			infoMeasurement.AppendLine("time of execution: " + elSec + " seconds");
			ParametersClass.log.Info(infoMeasurement);
			
		}
		#endregion
		
		#region bw Generate File - progress report send
		void bwGenerate_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			statusMsg ("Processing " + e.ProgressPercentage + "% ...",Color.DarkSlateBlue);
		}

		#endregion
		
		#region bw Generate File - STOP button
		void stopBwGenerate()
		{
			//if worker still does the job, send a flag to stop
			if (ParametersClass.BwGenerate.IsBusy)
				ParametersClass.BwGenerate.CancelAsync();
		}


		#endregion
		
		#endregion
	}
}

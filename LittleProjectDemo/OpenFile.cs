/*
 * Created by SharpDevelop.
 * User: Elektrolit
 * Date: 11.9.2018.
 * Time: 9:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LittleProjectDemo
{
	/// <summary>
	/// maybe later i will use this class for other file or sth else..
	/// </summary>
	public class OpenFile
	{
		#region OpenFile: bool LittleProjectDemo and save to List
		public static bool boolOpenFile (string path, string fileName, List<LittleProjectDemoClass> list)
		{
			bool isAllright=false;
			
			if (!CheckFile (path, fileName, ParametersClass.HeaderRowCsv)) {
				MessageBox.Show ("Error reading file");
				ParametersClass.log.Info ("Error reading file!!\nPath:" + path + "\nFile name: " + fileName);
			}
			else {
				var tcf = new LittleProjectDemoClassFunctions ();
				var line = string.Empty;
				using (var streamFile = new StreamReader (path + fileName, Encoding.Default)) {
					while ((line = streamFile.ReadLine ()) != null) {
						if (line.StartsWith (ParametersClass.HeaderRowCsv))
							continue; //skip the first line in file
						tcf.InsertIntoList (line, list);
					}
				}
				isAllright=true;
			}
			return isAllright;
		}
		#endregion
		
		#region CheckFile: LittleProjectDemo
		public static bool CheckFile (string path, string fileName, string headerRowCsv)
		{
			// check if file exist and 
			// check if file is really LittleProjectDemo or sth else
			var a = false;
			try {
				if (File.Exists (path + fileName)) {
					using (var sr = new StreamReader (path + fileName, Encoding.Default)) {
						string line1 = sr.ReadLine ();
						if (line1.Equals (headerRowCsv))
							a = true;
						else {
							string msg = "First row not identical..\nExpected:\n" + headerRowCsv + "\nActual:\n" + line1;
							ParametersClass.log.Info (msg);
						}
					}
				} else
					ParametersClass.log.Info ("File does not exist! " + path + fileName);
			} catch (Exception e) {
				ParametersClass.log.Info ("Error reading file: " + e);
			}
			return a;
		}
		#endregion
	}
}

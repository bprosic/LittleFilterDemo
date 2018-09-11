/*
 * Created by SharpDevelop.
 * User: Elektrolit
 * Date: 11.9.2018.
 * Time: 9:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Reflection;

namespace LittleProjectDemo
{
	/// <summary>
	/// Is this good alternative for Global Varaibles ??
	/// </summary>
	public class ParametersClass
	{
		public ParametersClass()
		{
		}
		
		#region vars
		//Datei parameter
		public static string fileName_ = string.Empty;
		public static string filePath_ = string.Empty;
		//vieviel indexes to filter.
		public static int artIndexNum_ = 3;
		//header row in Datei
		public const string HeaderRowCsv = "ID_NR;ID_NR_INDEX;NAME;SOME_NUMBERS;SOME_NUMBERS1;SOME_NUMBERS2;SOME_NUMBERS3;SN4;SN5;SN6;SN7;SN8;SN9;SN10;SN11;SN12;SN13;SN14;SN15;SN16;SN17;SN18;SN19;SN20;SN21;SN22;SN23;SN24;SN25;SN26;SN27";
		//logger
		public static readonly log4net.ILog log = log4net.LogManager.GetLogger (MethodBase.GetCurrentMethod ().DeclaringType);
		
		//für BW Report
		public static Int32 bwCounterPercent_;
		public static Int32 countTotalRowsInFile_;
		public static BackgroundWorker bwGenerate_;
		
		//init classes
		public static LittleProjectDemoClass tc_;
		public static LittleProjectDemoClassFunctions tcf_;
		
		//diese ist für Background Worker - to calculate progress percent
		public static BackgroundWorker BwGenerate {
			get { return bwGenerate_; }
			set { bwGenerate_ = value; }
		}
		public static Int32 CountTotalRowsInFile {
			get	{ return countTotalRowsInFile_; }
			set	{ countTotalRowsInFile_ = value; }
		}
		
		public static Int32 BwCounterPercent {
			get	{ return bwCounterPercent_; }
			set	{ bwCounterPercent_ = value; }
		}
		
		//benutzt für File path und File name für process
		public static string FileName {
			get { return fileName_; }
			set { fileName_ = value; }
		}
		
		public static string FilePath {
			get { return filePath_; }
			set { filePath_ = value; }
		}
		//hier ist ein Nummer für viviel Indexes brauchen wir für filter
		public static int ArtIndexNum {
			get { return artIndexNum_; }
			set { artIndexNum_ = value; }
		}
		
		//ist diese logik ok???
		public static LittleProjectDemoClass Tc {
			get{ return tc_; }
			set { tc_ = value; }
		}
		
		public static LittleProjectDemoClassFunctions Tcf {
			get { return tcf_; }
			set { tcf_ = value; }
		}
		#endregion
		
	}
}

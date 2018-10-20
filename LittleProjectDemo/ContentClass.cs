/*
 * Created by SharpDevelop.
 * User: Elektrolit
 * Date: 11.9.2018.
 * Time: 9:21
 * 
 */
using System;
using System.Collections.Generic;

namespace LittleProjectDemo
{
	/// <summary>
	// data structure
	/// </summary>
	
	#region LittleProjectDemoClass
	public class LittleProjectDemoClass
	{
		public string IdNr { get; set; }
		public string IdNrIndex{ get; set; }
		public string Name { get; set; }
		public string SomeNumbers { get; set; }
		public string SomeNumbers1 { get; set; }
		public string SomeNumbers2 { get; set; }
		public string SomeNumbers3 { get; set; }
		public string Sn4 { get; set; }
		public string Sn5 { get; set; }
		public string Sn6 { get; set; }
		public string Sn7 { get; set; }
		public string Sn8 { get; set; }
		public string Sn9 { get; set; }
		public string Sn10 { get; set; }
		public string Sn11 { get; set; }
		public string Sn12 { get; set; }
		public string Sn13 { get; set; }
		public string Sn14 { get; set; }
		public string Sn15 { get; set; }
		public string Sn16 { get; set; }
		public string Sn17 { get; set; }
		public string Sn18 { get; set; }
		public string Sn19 { get; set; }
		public string Sn20 { get; set; }
		public string Sn21 { get; set; }
		public string Sn22 { get; set; }
		public string Sn23 { get; set; }
		public string Sn24 { get; set; }
		public string Sn25 { get; set; }
		public string Sn26 { get; set; }
		public string Sn27 { get; set; }
	}
	#endregion
		
	#region LittleProjectDemoClassFunctions
	public class LittleProjectDemoClassFunctions
	{
		
		#region some list to store info
		public List<LittleProjectDemoClass> LittleProjectDemoList;
		#endregion
		
		//PascalCasing
		#region insertion to dict
		public void InsertIntoList (string x, List<LittleProjectDemoClass> lst)
		{
			const int howManySemicolonsNeeded = 30;
			if (x.Length == 0)
				return;
			var countSemicolons = 0;
			foreach (var ar in x) {
				if (ar.Equals (';'))
					countSemicolons++;
			}
			
			if (countSemicolons != howManySemicolonsNeeded)
				return;
			
			string[] s = x.Split (';');
			lst.Add (new LittleProjectDemoClass () {
				IdNr = s [0],
				IdNrIndex = s [1],
				Name = s [2],
				SomeNumbers = s [3],
				SomeNumbers1 = s [4],
				SomeNumbers2 = s [5],
				SomeNumbers3 = s [6],
				Sn4 = s [7],
				Sn5 = s [8],
				Sn6 = s [9],
				Sn7 = s [10],
				Sn8 = s [11],
				Sn9 = s [12],
				Sn10 = s [13],
				Sn11 = s [14],
				Sn12 = s [15],
				Sn13 = s [16],
				Sn14 = s [17],
				Sn15 = s [18],
				Sn16 = s [19],
				Sn17 = s [20],
				Sn18 = s [21],
				Sn19 = s [22],
				Sn20 = s [23],
				Sn21 = s [24],
				Sn22 = s [25],
				Sn23 = s [26],
				Sn24 = s [27],
				Sn25 = s [28],
				Sn26 = s [29],
				Sn27 = s [30]
			});
		}
		#endregion
	}
	#endregion
}

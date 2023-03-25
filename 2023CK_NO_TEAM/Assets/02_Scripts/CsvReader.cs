using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace _02_Scripts
{
	public class CsvReader
	{
		private const string SplitRe = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
		private const string LineSplitRe = @"\r\n|\n\r|\n|\r";
		static readonly char[] TrimChars = { '\"' };
    
		public static List<Dictionary<string, object>> Read(string file)
		{
			var list = new List<Dictionary<string, object>>();
			TextAsset data = Resources.Load (file) as TextAsset;

			if (data == null) return null;
			var lines = Regex.Split (data.text, LineSplitRe);
        
			if(lines.Length <= 1) return list;
        
			var header = Regex.Split(lines[0], SplitRe);
			for(var i=1; i < lines.Length; i++) {
            
				var values = Regex.Split(lines[i], SplitRe);
				if(values.Length == 0 ||values[0] == "") continue;
            
				var entry = new Dictionary<string, object>();
				for(var j=0; j < header.Length && j < values.Length; j++ ) {
					string value = values[j];
					value = value.TrimStart(TrimChars).TrimEnd(TrimChars).Replace("\\", "");
 
					value = value.Replace("<br>", "\n"); // 추가된 부분. 개행문자를 \n대신 <br>로 사용한다.
					value = value.Replace("<c>", ",");
 
					object finalvalue = value;
					int n;
					float f;
					if(int.TryParse(value, out n)) {
						finalvalue = n;
					} else if (float.TryParse(value, out f)) {
						finalvalue = f;
					}
					entry[header[j]] = finalvalue;
				}
				list.Add (entry);
			}
			return list;
		}
	}
}
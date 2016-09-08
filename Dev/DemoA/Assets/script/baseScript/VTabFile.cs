using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

using UnityEngine;

public class VTabFile {
	private int ColCount;  
	private Dictionary<string, int> ColIndex = new Dictionary<string, int>();
	private Dictionary<int, List<string>> TabInfo = new Dictionary<int, List<string>>();

	public VTabFile() {} 


	public VTabFile(string fileName) : this()
	{
		DoLoad(fileName);
	}

	#region load
	public void DoLoad(string fileName)
	{
		string text = LoadSettingOutPackage(fileName, true);
		ParseString(text);
	}

	string LoadSettingOutPackage(string path,bool isGBK){
		string fullPath = null;
		if(Application.platform == RuntimePlatform.Android){
			fullPath = "jar:file://" + Application.dataPath + "!/assets/" + path;
		}else if(Application.platform == RuntimePlatform.IPhonePlayer){
			fullPath ="file://" + Application.dataPath + "/Raw/" + path;
		}else if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer){
			fullPath = "file://" + Application.dataPath + "/StreamingAssets/" + path;
		}

		WWW www  = new WWW(fullPath);
		while(!www.isDone)
			System.Threading.Thread.Sleep(1);
		System.Text.Encoding encoding = System.Text.Encoding.UTF8;
		return encoding.GetString(www.bytes);
	}

	private bool ParseString(string content)
	{
		using (StringReader oReader = new StringReader(content))
		{
			ParseReader(oReader);
		}
		
		return true;
	}

	private bool ParseReader(TextReader oReader)
	{
		string sLine = "";
		char[] separator = { '\t' };
		int indexLine = 1;
		
		sLine = oReader.ReadLine();
		if (sLine == null)
		{
			return true;
		}
		
		string[] splitString = sLine.Split(separator);
		for (int i = 1; i <= splitString.Length; i++)
		{
			ColIndex[splitString[i - 1].Trim()] = i; 
		}
		ColCount = splitString.Length;
		
		List<string> arrlist = new List<string>(splitString);
		
		TabInfo[indexLine] = arrlist;
		indexLine++;
		while (sLine != null)
		{
			sLine = oReader.ReadLine();
			if (sLine != null)
			{
				string[] splitString1 = sLine.Split(separator);
				List<string> arrlist1 = new List<string>(splitString1);
				while (arrlist1.Count < ColCount)
					arrlist1.Add("");  
				
				TabInfo[indexLine] = arrlist1;
				indexLine++;
			}
		}
		return true;
	}
	#endregion

	#region get Data
	
	public string GetString(int row, int column)
	{
		if (column == 0) 
			return string.Empty;
		
		return TabInfo[row][column - 1].ToString();
	}
	
	public string GetString(int row, string columnName)
	{
		int column;
		if (!ColIndex.TryGetValue(columnName, out column))
			return string.Empty;
		
		return GetString(row, column);
	}
	
	public int GetInteger(int row, int column)
	{
		try
		{
			string field = GetString(row, column);
			return int.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public int GetInteger(int row, string columnName)
	{
		try
		{
			string field = GetString(row, columnName);
			return int.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public uint GetUInteger(int row, int column)
	{
		try
		{
			string field = GetString(row, column);
			return uint.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public uint GetUInteger(int row, string columnName)
	{
		try
		{
			string field = GetString(row, columnName);
			return uint.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	public double GetDouble(int row, int column)
	{
		try
		{
			string field = GetString(row, column);
			return double.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public double GetDouble(int row, string columnName)
	{
		try
		{
			string field = GetString(row, columnName);
			return double.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public float GetFloat(int row, int column)
	{
		try
		{
			string field = GetString(row, column);
			return float.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public float GetFloat(int row, string columnName)
	{
		try
		{
			string field = GetString(row, columnName);
			return float.Parse(field);
		}
		catch
		{
			return 0;
		}
	}
	
	public bool GetBool(int row, int column)
	{
		int field = GetInteger(row, column);
		return field != 0;
	}
	
	public bool GetBool(int row, string columnName)
	{
		int field = GetInteger (row, columnName);
		return field != 0;
	}
	#endregion

	public int GetHeight()
	{
		return TabInfo.Count;
	}
	
	public int GetWidth()
	{
		return ColCount;
	}
}

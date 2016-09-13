using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class VClientplayer
{
	private PlayerBaseData _BaseDada;

	public VClientplayer ()
	{

	}

	public void Init(){
		_BaseDada = new PlayerBaseData();

		LoadPlayerSetting();
		//TODO: 读取本地文件，获得缓存的数值
	}

	public void SetName(string name){ _BaseDada.Name = name;	}
	public void SetAge(int age){ _BaseDada.Age = age; }
	public void SetHeroId(int heroId){_BaseDada.HeroId = heroId;}

	public string GetName(){ return _BaseDada.Name; }
	public int GetAge(){ return _BaseDada.Age; }
	public int HeroId {
		get{
			return this._BaseDada.HeroId;
		}
	}

	public void SaveData(){
		//TODO: 保存 当前数据 进入 本地缓存
	}

	/// <summary>
	/// 是否已经登记注册
	/// </summary>
	public bool IsRegisted{
		get{
			if(_BaseDada.Name == string.Empty)
				return false;
			else return true;
		}
	}


	public void LoadPlayerSetting(){
		if (!System.IO.File.Exists(Application.persistentDataPath + "/gamesetting/user/user_config.tab")){
			_BaseDada.Name = string.Empty;
			_BaseDada.Age = -1;
			return ;
		}

		VTabFile tab = new VTabFile(Main.ClientPlayerDataPath);
		//int height = tab.GetHeight();

		//string test = tab.GetString(2, "Age");

		_BaseDada.Name = tab.GetString(2, "Name");
		_BaseDada.Age = tab.GetInteger(2, "Age");
		_BaseDada.HeroId = tab.GetInteger(2, "HeroId");

	}

	public void SavePlayerSettings()
	{
		string filePath = Application.persistentDataPath + "/gamesetting/user/";
		string fileName = "user_config.tab";
		if (System.IO.File.Exists(filePath+fileName))
			System.IO.File.Delete(filePath+fileName);

		if (!Directory.Exists(filePath))
		{
			Directory.CreateDirectory(filePath);
		}

		FileStream fs = System.IO.File.Create(filePath+fileName);
		StreamWriter sw = new StreamWriter(fs);
		string str = "Name" + '\t' + "Age"+ "\t" + "WaveNo" + '\t'+"HeroId" + '\t'+ '\r' + '\n';
//		string str = "Lvl" + '\t' + "Exp" + '\t' + "WaveNo" + '\t' + "LeftTime" + '\t' + "CompletedTask" + "\t" + '\r' + '\n';
		sw.Flush();
		sw.Write(str);
		sw.Close();
		fs.Close();		

		VTabFile tabFile = VTabFile.LoadFromFile(filePath+fileName);
		tabFile.SetValue<string>(2, 1, _BaseDada.Name);
		tabFile.SetValue<int>(2, 2, _BaseDada.Age);
		tabFile.SetValue<float>(2, 3, 13.0f);

		tabFile.Save("/gamesetting/user/user_config.tab");
	}


}

using System;

public class VClientplayer
{
	private PlayerBaseData _BaseDada;

	public VClientplayer ()
	{

	}

	public void Init(){
		_BaseDada = new PlayerBaseData();
		//TODO: 读取本地文件，获得缓存的数值
	}

	public void SetName(string name){ _BaseDada.Name = name;	}
	public void SetAge(int age){ _BaseDada.Age = age; }

	public string GetName(){ return _BaseDada.Name; }
	public int GetAge(){ return _BaseDada.Age; }

	public void SaveData(){
		//TODO: 保存 当前数据 进入 本地缓存
	}

}

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VAnimalTemManager
{
	public VAnimalTemManager ()
	{

	}

	private Dictionary<int,VAnimalInfo> HeroSetting = new Dictionary<int,VAnimalInfo>();
	private Dictionary<int,VAnimalInfo> MonsterSetting = new Dictionary<int,VAnimalInfo>();
	private Dictionary<int,VAnimalInfo> DeskSetting = new Dictionary<int,VAnimalInfo>();

	public void Init(){
		Load(HeroSetting,Main.HeroDataPath);
		Load(MonsterSetting,Main.MonsterDataPath);
		Load(DeskSetting,Main.DeskDataPath);
	}

	public void Load(Dictionary<int,VAnimalInfo> setting,string path)
	{
		setting.Clear();
		
		VTabFile tab = new VTabFile(path);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VAnimalInfo info = new VAnimalInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.Path = tab.GetString(row, "Path");
			info.Name = tab.GetString(row, "Name");
			info.MoveSpeed = tab.GetFloat(row, "Speed");
			info.BirthPos = new Vector3(tab.GetFloat(row,"X"),tab.GetFloat(row,"Y"),tab.GetFloat(row,"Z"));

			setting.Add(info.Id,info);
		}
	}
	
	
	public void Reset(){}
	
	public void Clear(){}
	
	public VAnimalInfo GetHero(int id){
		if(this.HeroSetting.ContainsKey(id))
			return this.HeroSetting[id];
		return null;
	}

	public VAnimalInfo GetMonster(int id){
		if(this.MonsterSetting.ContainsKey(id))
			return (VAnimalInfo)this.MonsterSetting[id];
		return null;
	}

	public VAnimalInfo GetDesk(int id){
		if(this.DeskSetting.ContainsKey(id))
			return (VAnimalInfo)this.DeskSetting[id];
		return null;
	}



}

public class VAnimalInfo{
	public int Id;
	public string Path;
	public string Name;
	public float MoveSpeed;
	public Vector3 BirthPos = Vector3.zero;
}

public class VHeroInfo : VAnimalInfo{

}

public class VMonsterInfo : VAnimalInfo{
}

public class VDeskInfo : VAnimalInfo{

}
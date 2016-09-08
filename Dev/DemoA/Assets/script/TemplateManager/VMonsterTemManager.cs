using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class VMonsterTemManager
{
	public VMonsterTemManager ()
	{
	}

	
	private Dictionary<int,VHeroInfo> MonsterSetting = new Dictionary<int,VHeroInfo>();
	
	public void Init(){
		Load();
	}
	
	public void Load()
	{
		
		VTabFile tab = new VTabFile(Main.MonsterDataPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VHeroInfo info = new VHeroInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.Path = tab.GetString(row, "Path");
			info.Name = tab.GetString(row, "Name");
			info.MoveSpeed = tab.GetFloat(row, "Speed");
			info.BirthPos = new Vector3(tab.GetFloat(row,"X"),tab.GetFloat(row,"Y"),tab.GetFloat(row,"Z"));

			MonsterSetting.Add(info.Id,info);
		}
	}
	
	
	public void Reset(){}
	
	public void Clear(){}
	
	public VHeroInfo GetMonster(int id){
		if(this.MonsterSetting.ContainsKey(id))
			return this.MonsterSetting[id];
		return null;
	}
}


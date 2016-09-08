using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VHeroManager
{
	public VHeroManager ()
	{

	}

	private Dictionary<int,VHeroInfo> HeroSetting = new Dictionary<int,VHeroInfo>();

	public void Init(){
		Load();
	}

	public void Load()
	{
		
		VTabFile tab = new VTabFile(Main.HeroDataPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VHeroInfo info = new VHeroInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.Path = tab.GetString(row, "Path");
			info.Name = tab.GetString(row, "Name");
			info.MoveSpeed = tab.GetFloat(row, "Speed");
			info.BirthPos = new Vector3(tab.GetFloat(row,"X"),tab.GetFloat(row,"Y"),tab.GetFloat(row,"Z"));

			HeroSetting.Add(info.Id,info);
		}
	}
	
	
	public void Reset(){}
	
	public void Clear(){}
	
	public VHeroInfo GetHero(int id){
		if(this.HeroSetting.ContainsKey(id))
			return this.HeroSetting[id];
		return null;
	}
}

public class VHeroInfo{
	public int Id;
	public string Path;
	public string Name;
	public float MoveSpeed;
	public Vector3 BirthPos = Vector3.zero;
}
using System;
using System.Collections;
using System.Collections.Generic;

public class MapManager
{

	private Dictionary<int,MapInfo> MapSetting = new Dictionary<int,MapInfo>();

	public MapManager ()
	{
	}


	public void Init(){
		Load();
	}


	public void Load()
	{
		
		VTabFile tab = new VTabFile(Main.MapDataPath);
		int height = tab.GetHeight();

		for (int row = 2; row <= height; row++)
		{
			MapInfo info = new MapInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.Ground = tab.GetInteger(row, "Ground");
			info.Monster = tab.GetInteger(row, "Monster");
			info.Desk = tab.GetInteger(row, "Desk");

			MapSetting.Add(info.Id,info);
		}
	}


	public void Reset(){}

	public void Clear(){}
	
	public MapInfo GetMap(int id){
		if(this.MapSetting.ContainsKey(id))
			return this.MapSetting[id];
		return null;
	}
}

public class MapInfo{
	public int Id;
	public int Ground;
	public int Monster;
	public int Desk;
}
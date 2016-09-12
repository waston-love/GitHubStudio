using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VStageTemManager
{
	public VStageTemManager ()
	{
	}

	private Dictionary<int,VStageInfo> _StageSetting = new Dictionary<int,VStageInfo>();
	
	public void Init(){
		Load();
	}
	
	public void Load()
	{
		
		VTabFile tab = new VTabFile(Main.StageDataPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VStageInfo info = new VStageInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.Name = tab.GetString(row, "Name");
			info.MapId = tab.GetInteger(row, "MapId");

			_StageSetting.Add(info.Id,info);
		}
	}
	
	
	public void Reset(){}
	
	public void Clear(){}
	
	public VStageInfo GetMap(int id){
		if(this._StageSetting.ContainsKey(id))
			return this._StageSetting[id];
		Debug.LogError("不含有 id:" + id.ToString() + "的 地图");
		return null;
	}

	public Dictionary<int,VStageInfo> StageSetting{
		get{
			return this._StageSetting;
		}
	}

}

public class VStageInfo{
	public int Id;
	public string Name;
	public int MapId;
}
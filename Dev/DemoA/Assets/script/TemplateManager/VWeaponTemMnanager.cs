using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class VWeaponTemMnanager
{
	public VWeaponTemMnanager ()
	{
	}

	
	private Dictionary<int,VWeaponInfo> _WeaponSetting = new Dictionary<int,VWeaponInfo>();
	
	public void Init(){
		Load();
	}
	
	public void Load()
	{
		
		VTabFile tab = new VTabFile(Main.WeaponDataPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VWeaponInfo info = new VWeaponInfo();
			info.Id = tab.GetInteger(row, "Id");
			info.ResName = tab.GetString(row, "ResName");
			info.Type = (WeaponType)tab.GetInteger(row, "Type");;
			info.HurtId = tab.GetInteger(row, "HurtId");
			info.AddHp =  tab.GetFloat(row, "AddHp");
			info.AddDefense =  tab.GetFloat(row, "AddDefense");
			info.AttackPhysic =  tab.GetFloat(row, "AttackPhysic");
			info.AddAttackCriticalPossibility =  tab.GetFloat(row, "AddAttackCriticalPossibility");
			info.AddMoveSpeed =  tab.GetFloat(row, "AddMoveSpeed");

			_WeaponSetting.Add(info.Id,info);
		}
	}
	
	
	public void Reset(){}
	
	public void Clear(){}

	public VWeaponInfo GetWeapon(int id){
		if(this._WeaponSetting.ContainsKey(id))
			return this._WeaponSetting[id];
		Debug.LogError("不含有 id:" + id.ToString() + "的 武器");
		return null;
	}

}


public class VWeaponInfo{
	public int Id;
	public string ResName;
	public WeaponType Type;
	public int HurtId;
	public float AddHp;
	public float AddDefense;
	public float AttackPhysic;
	public float AddAttackCriticalPossibility;
	public float AddMoveSpeed;
}

public enum WeaponType : byte{
	RecentAttack = 1,
	FarAttack = 2,
}
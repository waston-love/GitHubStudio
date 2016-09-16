using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Spine.Unity;


public class VWeapon
{
	private VWeaponInfo _WeaponInfo;
	private VAnimal _Parent;

	public VWeapon ()
	{

	}

	public VWeaponInfo VWeaponInfo;


	public void Init(VAnimal ani,int weaponId){
		this._Parent = ani;
		this._WeaponInfo = VGame.Instance.WeaponTemManager.GetWeapon(weaponId);
	}

	public void Attack(){
		//TODO： process a hurtsphere
		float hurtVal = this._Parent.Attribute.AttackPhysic + this._WeaponInfo.AttackPhysic;

	}

}



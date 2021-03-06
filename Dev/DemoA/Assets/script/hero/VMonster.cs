using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VMonster : VAnimal
{
	
	public VMonster ()
	{
		
	}
	
	public override void Init(VAnimalInfo info,Vector3 pos,int weaponId) {
		base.Init(info,pos,weaponId);
	}
	
	
	public override void SetupSkill(int skillId){}
	
	
	public Transform Handle{ 
		get {
			return this._Handle;
		} 
	}
	
	public override void Move(Direct dir){
		base.Move(dir);
		
	}
	
	public float Timer = 0;
	
	public override void Active(){
		base.Active();
		
	}
	
	private Transform _Effect;
	public override void Attack(){
		base.Attack();
		
	}
	
	public override void Hurt(float val){
		base.Hurt(val);
	}
	
	IEnumerator DestroyEffect(Transform t){
		yield return new WaitForSeconds(0.8f);
		
		UnityEngine.Object.Destroy(t.gameObject);
		
	}
	
	
}


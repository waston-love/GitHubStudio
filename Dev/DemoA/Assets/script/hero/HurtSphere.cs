using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class HurtSphere
{
	private VHero _Parent;
	private float _EndTime;
	private Vector3 _Position;

	private List<VHero> _HurtList = new List<VHero>();

	public HurtSphere ()
	{
	}

	public void Init(float time,VHero parent,Vector3 pos){
		_EndTime = Time.time + time;
		_Position = pos;
	}

	public bool _IsSettle = false;

	public void Active(){
		if(this._EndTime <= Time.time){

			//TODO: 结算伤害
			foreach(VHero h in _HurtList){
				h.Hurt(5);
			}
			_IsSettle = true;
		}else{
			List<VHero> list = VGame.SceneManager.AllMonster;
			foreach(VHero h in list){
				if(Vector3.Distance(h.Handle.position,_Position)< 10){
					if(!_HurtList.Contains(h)){
						_HurtList.Add(h);

					}
						
				}
			}
		}
	}
}


using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VAnimal
{
	
	protected VAnimalInfo _Info;
	
	
	protected float _JumpSpeed;
	protected VHeroAttackState _State;
	protected float _AttackEndTime;
	
	protected float _HP;
	
	protected Transform _Handle;
	protected CharacterController _CC;
	protected Vector3 _Position;
	
	public VAnimal ()
	{
		
	}
	
	public virtual void Init(VAnimalInfo info,Vector3 pos){
		_Info = info;

		GameObject spr = GameObject.Instantiate(Resources.Load(info.Path+"/" + info.Id.ToString())) as GameObject;
		spr.name = info.Id.ToString();
		//spr.transform.localScale = Vector3.one;
		//spr.transform.position = info.BirthPos;
		spr.transform.position = pos;

		_Handle = spr.transform;
		
		_CC = this._Handle.gameObject.GetComponent<CharacterController>();
		_JumpSpeed = Main.Instance.JumpSpeed;
		
		_State = VHeroAttackState.Idle;
		_HP = 11;
	}
	
	
	public virtual void SetupSkill(int skillId){}
	
	
	public Transform Handle{ 
		get {
			return this._Handle;
		} 
	}
	
	public virtual void Move(Direct dir){
		if(dir == Direct.Down){
			this._CC.Move(new Vector3(0,0,-_Info.MoveSpeed * Time.deltaTime));
		}else if(dir == Direct.Up){
			this._CC.Move(new Vector3(0,0,_Info.MoveSpeed * Time.deltaTime));
		}else if(dir == Direct.Right){
			this._CC.Move(new Vector3(_Info.MoveSpeed * Time.deltaTime,0,0));
		}else if(dir == Direct.Left){
			this._CC.Move(new Vector3(-_Info.MoveSpeed * Time.deltaTime,0,0));
		}else if(dir == Direct.Jump){
			Timer = 0;
			_JumpSpeed = Main.Instance.JumpSpeed;
		}else if(dir == Direct.Attack){
			this.Attack();
		}
	}
	
	public float Timer = 0;
	
	public virtual void Active(){
		Timer += Time.deltaTime;
		this._CC.Move(new Vector3(0,_JumpSpeed -Main.Instance.Gravity * Timer * Timer / 2,0));
		
		if(_State == VHeroAttackState.Attack && _AttackEndTime<= Time.time){
			if(_Effect !=null)
				UnityEngine.Object.Destroy(_Effect.gameObject);
			_State = VHeroAttackState.Idle;
		}
		
	}
	
	private Transform _Effect;
	public virtual void Attack(){
		if(this._State == VHeroAttackState.Idle){
			
			this._State = VHeroAttackState.Attack;
			_AttackEndTime = Time.time + 1.8f;
			
			GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
			temp.transform.position = this._Handle.transform.position + new Vector3(3,0,0);
			
			
			
			_Effect = temp.transform;
			_Effect.GetComponent<BoxCollider>().enabled = false;
			
			HurtSphere hurt = new HurtSphere();
			hurt.Init(1.8f,this,this.Handle.position+ new Vector3(3,0,0));
			VGame.SceneManager.HurtTab.Add(hurt);
			
			
			//TODO: 释放一个 拥有 伤害半径的 伤害球 
			
			
		}else{
			
		}
	}
	
	public virtual void Hurt(float val){
		_HP -= val;
		Debug.Log("扣血： " + _HP.ToString() + "  " + val.ToString());
		if(_HP <= 0){
			Debug.Log("Death");
		}
	}
	
	IEnumerator DestroyEffect(Transform t){
		yield return new WaitForSeconds(0.8f);
		
		UnityEngine.Object.Destroy(t.gameObject);
		
	}
	
	
}



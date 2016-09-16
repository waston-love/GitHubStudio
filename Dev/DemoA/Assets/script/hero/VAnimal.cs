using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Spine.Unity;

public class VAnimal
{
	
	protected VAnimalInfo _Info;
	
	
	protected float _JumpSpeed;
	protected VHeroAttackState _State;
	protected float _AttackEndTime;
	
	protected float _HP;
	
	protected Transform _Handle;
	protected CharacterController _CC;
	protected SkeletonAnimation _Animation;
	protected Vector3 _Position;

	protected FaceType _FaceType;

	VAnimation Ani;

	protected VAttribute _Attribute;

	protected VWeapon _Weapon;

	public VAnimal ()
	{
		
	}

	#region 接口
	public FaceType FaceType{
		get{
			return this._FaceType;
		}
		set{

			if(this._FaceType == value){
				return;
			}
			this._FaceType = value;
			this.TurnFace(this._FaceType);
		}
	}
	public VHeroAttackState State{
		get{
			return this._State;
		}
		set{
			if(this._State == value)
				return;
			this._State = value;

			this.TurnAnimation(this._State);
		}
	}
	public Transform Handle{ 
		get {
			return this._Handle;
		} 
	}
	public VAttribute Attribute{
		get{
			return this._Attribute;
		}
	}
	#endregion

	#region Init
	public virtual void Init(VAnimalInfo info,Vector3 pos,int weaponId){
		_Info = info;

		GameObject spr = GameObject.Instantiate(Resources.Load(info.Path+"/" + info.Id.ToString())) as GameObject;
		spr.name = info.Id.ToString();
		spr.transform.position = pos;

		_Handle = spr.transform;		
		_CC = this._Handle.gameObject.GetComponent<CharacterController>();
		if(_CC == null)
			_CC = this._Handle.gameObject.AddComponent<CharacterController>();
		_JumpSpeed = Main.Instance.JumpSpeed;

		_Animation = this._Handle.gameObject.GetComponent<SkeletonAnimation>();
		if(_Animation == null)
			Debug.LogError(info.Id+ " 没有骨骼动画 ");

		_State = VHeroAttackState.Idle;

		_HP = 11;

		//TODO: 此处确定 人物初始朝向
		int face = 1;
		if(face.Equals(FaceType.Left)){
			this.FaceType = FaceType.Left;
		}else if(face.Equals(FaceType.Right)){
			this.FaceType = FaceType.Right;
		}

		_Attribute = new VAttribute();
		_Attribute.Init(info);

		_Weapon = new VWeapon();
		_Weapon.Init(this,weaponId);
	}
	
	
	public virtual void SetupSkill(int skillId){}
	
	#endregion

	#region Method
	public virtual void Move(Direct dir){
		if(dir == Direct.Down){
			this._CC.Move(new Vector3(0,0,-_Attribute.MoveSpeed * Time.deltaTime));
		}else if(dir == Direct.Up){
			this._CC.Move(new Vector3(0,0,_Attribute.MoveSpeed * Time.deltaTime));
		}else if(dir == Direct.Right){
			this._CC.Move(new Vector3(_Attribute.MoveSpeed * Time.deltaTime,0,0));
			this.FaceType = FaceType.Right;
		}else if(dir == Direct.Left){
			this._CC.Move(new Vector3(-_Attribute.MoveSpeed * Time.deltaTime,0,0));
			this.FaceType = FaceType.Left;
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
		
		if(State == VHeroAttackState.Attack && _AttackEndTime<= Time.time){
			if(_Effect !=null)
				UnityEngine.Object.Destroy(_Effect.gameObject);
			State = VHeroAttackState.Idle;
		}
		
	}
	
	private Transform _Effect;


	public virtual void Attack(){

		if(this.State == VHeroAttackState.Idle){
			
			this.State = VHeroAttackState.Attack;
			_AttackEndTime = Time.time + 0.85f;
			
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
	
	private void TurnFace(FaceType type){
		switch(type){
			case FaceType.Left :
				this._Handle.rotation = Quaternion.Euler(new Vector3(0,180,0));				
				break;
			case FaceType.Right :
				this._Handle.rotation = Quaternion.Euler(new Vector3(0,0,0));		

				break;
		}
	}
	public void TurnAnimation(VHeroAttackState state){

		switch(state){
		case VHeroAttackState.Idle :
			this._Animation.state.SetAnimation(0,"walk",true);
			break;
		case VHeroAttackState.Attack :
			this._Animation.state.SetAnimation(0,"attack",true);
			break;
		}

	}
	#endregion

}


public enum FaceType : ushort{
	Left = 1,
	Right = 2,
}

public class VAnimation{
	SkeletonAnimation Ani ;
	public VAnimation(SkeletonAnimation ani){
		Ani  = ani;
	}

	public void SetState(string state){

		Ani.state.SetAnimation(0,state,false);
	}
}

public class VAttribute{
	
	public void Init(VAnimalInfo info){
		Hp = info.Hp;		
		AttackPhysic = info.AttackPhysic;		
		AttackCriticalPossibility = info.AttackCriticalPossibility;		
		MoveSpeed = info.MoveSpeed;		
	}

	public float Hp;
	public float Defense;
	public float AttackPhysic;
	public float AttackCriticalPossibility;
	public float MoveSpeed;
}


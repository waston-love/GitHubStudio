using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SceneManager
{
	private Dictionary<int,Transform> _ScenePool = new Dictionary<int, Transform>();

	private VHero _Captain;
	private Dictionary<int,VHero> _MonsterTab = new Dictionary<int, VHero>();

	public List<HurtSphere> HurtTab = new List< HurtSphere>();

	public SceneManager ()
	{
	}


	public void Init(){}
	void Reset(){}
	void Clear(){
		ClearMap();
	}



	void LoadHero(int Id){

		_Captain = new VHero();
		VHeroInfo info = VGame.Instance.HeroManager.GetHero(2000001);
		_Captain.Init(info);

	}

	void LoadMonster(){
		VHero monster = new VHero();
		VHeroInfo info = VGame.Instance.MonsterManager.GetMonster(2000101);
		monster.Init(info);

		_MonsterTab.Add(info.Id,monster);
	}

	void ClearHero(){}
	
	public void StartGame(){
		Clear();
		LoadMap(1);
		LoadHero(1);
		LoadMonster();

		VRepresent.UIManager.OpenWindow<VUIPlayerInofoWindow>();

	}
	
	public void Input(Direct dir){

		if(this._Captain == null)
			return;

		this._Captain.Move(dir);
	}

	
	public void Active(){

		if(this._Captain == null)
			return;
		
		this._Captain.Active();
		foreach(VHero hero in _MonsterTab.Values){
			hero.Active();
		}

		List<HurtSphere> list = new List<HurtSphere>();
		foreach(HurtSphere hurt in HurtTab){
			hurt.Active();
			if(hurt._IsSettle)
				list.Add(hurt);
		}

		foreach(HurtSphere h in list){
			HurtTab.Remove(h);
		}

	}

	void LoadMap(int Id){
		MapInfo info = VGame.Instance.MapManager.GetMap(1000001);

		GameObject spr = GameObject.Instantiate(Resources.Load(info.Path+"/" + info.Id.ToString())) as GameObject;
		spr.name = info.Id.ToString();
		//spr.transform.localScale = Vector3.one;
		spr.transform.position = Vector3.zero;
		//spr.transform.rotation = Quaternion.Euler(Vector3.zero);

		_ScenePool.Add(info.Id,spr.transform);
	}

	void ClearMap(){
		List<Transform> list = new List<Transform>();
		foreach(Transform t in this._ScenePool.Values){
			list.Add(t);
		}

		this._ScenePool.Clear();
		foreach(Transform t in list){
			UnityEngine.Object.Destroy(t.gameObject);;
		}
	}

	public List<VHero> AllMonster{
		get{
			List<VHero> list = new List<VHero>();
			foreach(VHero t in this._MonsterTab.Values){
				list.Add(t);
			}
			return list;
		}
	}
}



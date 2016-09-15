using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SceneManager
{
	private Dictionary<int,Transform> _ScenePool = new Dictionary<int, Transform>();

	private VHero _Captain;
	private Dictionary<int,VMonster> _MonsterTab = new Dictionary<int, VMonster>();
	private Dictionary<int,VDesk> _DeskTab = new Dictionary<int, VDesk>();

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
		VAnimalInfo info = VGame.Instance.AnimalTemManager.GetHero(Id);
		_Captain.Init(info,new Vector3(-2,-1.8f,-3));

	}

	void LoadDesk(MapInfo map){
		VDesk desk = new VDesk();
		VAnimalInfo info = VGame.Instance.AnimalTemManager.GetDesk(map.Desk);
		desk.Init(info,new Vector3(2,2,-8));
		_DeskTab.Add(info.Id,desk);
	}

	void LoadMonster(MapInfo map){
		VMonster mon = new VMonster();
		VAnimalInfo info = VGame.Instance.AnimalTemManager.GetMonster(map.Monster);
		mon.Init(info,new Vector3(0,-0.5f,-2));
		_MonsterTab.Add(info.Id,mon);

	}

	void ClearHero(){}
	
	public void StartGame(int stageId){
		Clear();

		VStageInfo stageInfo = VGame.Instance.StageTemManager.GetMap(stageId);

		// ground
		MapInfo mapInfo = VGame.Instance.MapManager.GetMap(stageInfo.MapId);
		LoadGround(mapInfo.Ground);

		// monster
		LoadMonster(mapInfo);

		//

		// desk
		LoadDesk(mapInfo);

		// Hero
		LoadHero(VGame.Instance.Clientplayer.HeroId);


		VRepresent.UIManager.OpenWindow<VUIPlayerInofoWindow>(100.0f,75.0f);
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
		foreach(VMonster hero in _MonsterTab.Values){
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

	void LoadGround(int Id){
		//MapInfo info = VGame.Instance.MapManager.GetMap(10000001);
		string res_path = "prefab/" + (Id/10000000).ToString() + "/" + Id.ToString();

		GameObject spr = GameObject.Instantiate(Resources.Load(res_path)) as GameObject;
		spr.name = Id.ToString();

		spr.transform.position = Vector3.zero;

		//spr.transform.localScale = Vector3.one;
		//spr.transform.rotation = Quaternion.Euler(Vector3.zero);

		_ScenePool.Add(Id,spr.transform);
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

	public List<VMonster> AllMonster{
		get{
			List<VMonster> list = new List<VMonster>();
			foreach(VMonster t in this._MonsterTab.Values){
				list.Add(t);
			}
			return list;
		}
	}
}



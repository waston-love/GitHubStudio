using UnityEngine;
using System.Collections;

public class VGame {

	private static VGame _Instance;

	private bool InitBaseConfiged = false;
	private bool InitGameLogiced = false;

	public bool LoadFinished = false;

	public MapManager MapManager;
	public VHeroManager HeroManager;
	public VMonsterTemManager MonsterManager;
	public VStageTemManager StageTemManager;

	public VClientplayer Clientplayer ;


	public static SceneManager SceneManager;
	public static VInputController InputController;

	public static VGame Instance{
		get{
			if(_Instance == null)
				_Instance = new VGame();
			return _Instance;
		}
	}


	public IEnumerator InitGameBaseConfig()
	{
		Clientplayer = new VClientplayer();
		Clientplayer.Init();

		MapManager = new MapManager();
		MapManager.Init();

		HeroManager = new VHeroManager();
		HeroManager.Init();

		MonsterManager = new VMonsterTemManager();
		MonsterManager.Init();

		StageTemManager  =new VStageTemManager();
		StageTemManager.Init();

		InitBaseConfiged = true;
		CheckLoaded();
		yield return null;
	}

	public IEnumerator InitGameLogic(){



		SceneManager = new SceneManager();
		SceneManager.Init();

		InputController = new VInputController();
		InputController.Init();

		InitGameLogiced = true;
		CheckLoaded();
		yield return null;
	}
	private void CheckLoaded(){
		if(InitGameLogiced && InitBaseConfiged)
			LoadFinished = true;
	}

	public void Startup()
	{
		//Debug.Log("TODO ... 加载 场景~");
		//TODO: 加载 场景
		//Scene.LoadPlayerMap();

		//VRepresent.UIManager.OpenWindow<VUITitle>();
		VRepresent.UIManager.OpenWindow<VUIMainMenu>();
	}

	public void Active(){
		SceneManager.Active();
		InputController.Active();
	}
}







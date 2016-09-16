using UnityEngine;
using System.Collections;

public class VGame {

	private static VGame _Instance;

	private bool InitBaseConfiged = false;
	private bool InitGameLogiced = false;

	public bool LoadFinished = false;

	public MapManager MapManager;
	public VAnimalTemManager AnimalTemManager;

	public VStageTemManager StageTemManager;
	public VWeaponTemMnanager WeaponTemManager;

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

		AnimalTemManager = new VAnimalTemManager();
		AnimalTemManager.Init();


		StageTemManager  =new VStageTemManager();
		StageTemManager.Init();

		WeaponTemManager = new VWeaponTemMnanager();
		WeaponTemManager.Init();

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







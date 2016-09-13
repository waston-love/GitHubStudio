using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public static Main Instance;

	public VGame GameLogical;
	public VRepresent GameRepresent;

	void Awake(){
		Instance = this;

		GameLogical = VGame.Instance;
		GameRepresent = new VRepresent();
	}

	void Start () {
		StartCoroutine(ProcessLoading());
	
	}

	public IEnumerator ProcessLoading(){
		GameRepresent.InitUI();

		StartCoroutine(GameLogical.InitGameBaseConfig());
		StartCoroutine(GameLogical.InitGameLogic());

		while (!GameLogical.LoadFinished)
			yield return null;

		GameRepresent.InitRL();

		yield return null;

		yield return new WaitForEndOfFrame();

		yield return new WaitForSeconds(0.10f);

		VRepresent.UIManager.CloseWindow<VUILoading>();
		GameLogical.Startup();
	}

	void Update(){
		GameLogical.Active();
	}


	#region ConstData

	public static string BuildingDataPath = "gamesetting/house/building.tab";
	public static string IndustryDataPath = "gamesetting/house/industry.tab";
	public static string ShopDataPath = "gamesetting/house/shop.tab";
	public static string TemplateBuildingDataPath = "gamesetting/sprites/buildng.tab";
	public static string TemplateThingDataPath = "gamesetting/sprites/thing.tab";
	//public static string ClientPlayerDataPath = "gamesetting/user/user.tab";

	public static string MapDataPath = "gamesetting/map/map.tab";

	public static string StageDataPath = "gamesetting/map/stagepath.tab";

	public static string ClientPlayerDataPath = "gamesetting/user/user_config.tab";

	public static string HeroDataPath = "gamesetting/hero/hero.tab";
	public static string MonsterDataPath = "gamesetting/hero/monster.tab";
	public static string DeskDataPath = "gamesetting/hero/desk.tab";

	#endregion

	#region Debug
	public float Gravity = 9.8f;
	public float JumpSpeed = 9.8f;
	#endregion
}


public enum Direct : ushort{
	Up,
	Down,
	Left,
	Right,
	Jump,
	Attack,
}
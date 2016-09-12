using UnityEngine;
using System.Collections;

public class VRepresent {

	public static VUIManager UIManager;

	public  VRepresent(){}

	public void InitUI()
	{
		GameObject.Find("UI Root/Camera").gameObject.GetComponent<Camera>().orthographicSize = 1.78f;

		UIManager = GameObject.Find("UI Root/UIController").GetComponent<VUIManager>();
		UIManager.Init();
	}

	public void InitRL(){
		UIManager.OpenWindow<VUILoading>();
	}
}

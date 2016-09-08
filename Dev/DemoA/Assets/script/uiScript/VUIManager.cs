using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class VUIManager : MonoBehaviour {

	Dictionary<string, VUISetting> UISettings = new Dictionary<string,VUISetting>();
	Dictionary<string, VUIBase> UIWindows = new Dictionary<string, VUIBase>();
	public Transform UIRootCamera;

	public VUIManager (){}

	public void Init(){

		UIRootCamera = GameObject.Find("UI Root/Camera").transform;

		VTabFile tabFile = new VTabFile("gamesetting/ui/uisetting.tab");
		for (int i = 2; i <= tabFile.GetHeight(); ++i)
		{
			VUISetting uiSetting = new VUISetting();
			string uiName = tabFile.GetString(i, "UIName");
			uiSetting.UIName = uiName;
			uiSetting.Side = tabFile.GetString(i, "AnchorSide");
			uiSetting.OffsetX = tabFile.GetFloat(i, "OffsetX");
			uiSetting.OffsetY = tabFile.GetFloat(i, "OffsetY");
			uiSetting.OffsetZ = tabFile.GetFloat(i, "OffsetZ");
			
			UISettings[uiName] = uiSetting;
		}
	}

	public void OpenWindow<T>(params object[] args) where T : VUIBase
	{
		string uiName = typeof(T).Name.Remove(0, 3); 
		OpenWindow(uiName, args);
	}

	public void OpenWindow(string uiName, params object[] args)
	{
		VUIBase uiBase = null;
		if (!UIWindows.TryGetValue(uiName, out uiBase))
		{
			uiBase = LoadWindow(uiName, args);
			return;
		}
		
		OnOpen(uiBase, args);
	}

	VUIBase LoadWindow(string uiName, params object[] args)
	{        
		GameObject uiObj = Instantiate(Resources.Load<GameObject>("UI/" + uiName)) as GameObject;
		uiObj.SetActive(false);
		//uiObj.transform.parent = AnchorSide[UISettings[uiName].Side];
		uiObj.transform.parent = UIRootCamera;
		uiObj.transform.localPosition = new Vector3(UISettings[uiName].OffsetX, UISettings[uiName].OffsetY, UISettings[uiName].OffsetZ);
		uiObj.transform.localScale = Vector3.one;
		
		VUIBase uiBase = (VUIBase)uiObj.AddComponent(Type.GetType("VUI" + uiName));
		uiBase.OnInit();
		uiBase.UIName = uiName;
		
		UIWindows.Add(uiName, uiBase);
		OnOpen(uiBase, args);
		
		return uiBase;
	}

	void OnOpen(VUIBase uiBase, params object[] args)
	{
		uiBase.gameObject.SetActive(true);		
		uiBase.OnOpen(args);
	}

	public void CloseWindow<T>()
	{
		CloseWindow(typeof(T).Name.Remove(0, 3)); 
	}
	
	public void CloseWindow(string name)
	{
		VUIBase uiBase;
		if (!UIWindows.TryGetValue(name, out uiBase))
		{
			return;
		}
		
		//uiBase.gameObject.SetActive(false);
		uiBase.OnClose();
	}
}

public class VUISetting
{
	public string UIName;
	public string Side;
	public float OffsetX;
	public float OffsetY;
	public float OffsetZ;
}
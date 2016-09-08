using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUITitle : VUIBase 
{

	public override void OnOpen(params object[] args)
	{
		this.gameObject.SetActive(true);
	}
	
	public override void OnClose()
	{
		this.gameObject.SetActive(false);        
	}


	public override void OnInit()
	{
		EventDelegate.Add(FindControl<UIButton>("BtnHome").onClick,this._ClickHome);
		EventDelegate.Add(FindControl<UIButton>("BtnVillage").onClick,this._ClickVillage);
		EventDelegate.Add(FindControl<UIButton>("BtnAdvanture").onClick,this._ClickAdvanture);
	}

	#region ui event
	private void _ClickHome(){
		VRepresent.UIManager.OpenWindow<VUIHomePanel>();
	}
	private void _ClickVillage(){
		Debug.Log("Open Village");
	}
	private void _ClickAdvanture(){
		Debug.Log("Open Advanture");
	}
	#endregion


}

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUIRegisterName : VUIBase
{
	public VUIRegisterName ()
	{
	}

	private UILabel _InputName;
	private UILabel _InputAge;

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
		EventDelegate.Add(FindControl<UIButton>("BtnOK").onClick,this._ClickOK);

		_InputName = FindControl<UILabel>("InputName");
		_InputAge = FindControl<UILabel>("InputAge");

	}


	#region ui event
	private void _ClickOK(){
		Debug.Log("Name: " + _InputName.text);
		Debug.Log("Age: " + _InputAge.text);
		Debug.Log("赋值 玩家数据");

		VGame.SceneManager.StartGame();

		this.OnClose();
		VRepresent.UIManager.CloseWindow<VUIMainMenu>();
	}
	#endregion
}


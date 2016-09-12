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
	//private UILabel _InputAge;

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
		//_InputAge = FindControl<UILabel>("InputAge");

	}


	#region ui event
	private void _ClickOK(){

		VGame.Instance.Clientplayer.SetName(_InputName.text);

		VGame.Instance.Clientplayer.SavePlayerSettings();

		VRepresent.UIManager.OpenWindow<VUISubway>();
		//VGame.SceneManager.StartGame();
		//VGame.SceneManager.StartGame();

		this.OnClose();

	}
	#endregion
}


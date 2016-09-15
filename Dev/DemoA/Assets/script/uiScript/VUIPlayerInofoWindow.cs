using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUIPlayerInofoWindow : VUIBase
{

	private float _CapBlood;
	private float _CapBloodCurrent;

	UILabel _Name;

	private UISprite _Bloodorge;
	public VUIPlayerInofoWindow ()
	{
	}

	public override void OnOpen(params object[] args)
	{
		this.gameObject.SetActive(true);
		_Name.text = VGame.Instance.Clientplayer.GetName();
		_CapBlood = (float)args[0];
		_CapBloodCurrent = (float)args[1];
		_Bloodorge.fillAmount = _CapBloodCurrent / _CapBlood;
	}
	
	public override void OnClose()
	{
		this.gameObject.SetActive(false);        
	}
	
	
	public override void OnInit()
	{
		_Name = FindControl<UILabel>("Name");
		_Bloodorge = FindControl<UISprite>("HpForge");
			
	}
	
	public void DivBlood(float val){

	}

}
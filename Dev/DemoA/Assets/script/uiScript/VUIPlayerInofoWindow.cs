using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUIPlayerInofoWindow : VUIBase
{

	UILabel _Name;
	public VUIPlayerInofoWindow ()
	{
	}

	public override void OnOpen(params object[] args)
	{
		this.gameObject.SetActive(true);
		_Name.text = VGame.Instance.Clientplayer.GetName();
	}
	
	public override void OnClose()
	{
		this.gameObject.SetActive(false);        
	}
	
	
	public override void OnInit()
	{
		_Name = FindControl<UILabel>("Name");
	}
	


}
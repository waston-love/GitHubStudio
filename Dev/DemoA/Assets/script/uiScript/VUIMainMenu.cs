using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUIMainMenu: VUIBase
{
	public VUIMainMenu ()
	{
	}

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
		EventDelegate.Add(FindControl<UIButton>("BtnStart").onClick,this._ClickStart);
		EventDelegate.Add(FindControl<UIButton>("BtnExit").onClick,this._ClickExit);
	}

	#region ui event
	int test_num = 1;
	int test_num_BB = 3;
	private void _ClickStart(){
		test_num += 2;

		test_num_BB += 3;
		this.OnClose();

		test_num_BB += 3;

		test_num += 2;

		test_num_BB += 3;

		VGame.SceneManager.StartGame();
	}
	private void _ClickExit(){
		Debug.Log("Exit 退出游戏");
		Application.Quit();
	}
	#endregion
}



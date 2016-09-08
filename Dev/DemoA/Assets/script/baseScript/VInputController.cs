using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VInputController
{
	public VInputController ()
	{
	}

	
	public void Init(){}


	public void Active(){
		if(Input.GetKey(KeyCode.DownArrow)){
			VGame.SceneManager.Input(Direct.Down);
		}else if(Input.GetKey(KeyCode.UpArrow)){
			VGame.SceneManager.Input(Direct.Up);
		}else if(Input.GetKey(KeyCode.LeftArrow)){
			VGame.SceneManager.Input(Direct.Left);
		}else if(Input.GetKey(KeyCode.RightArrow)){
			VGame.SceneManager.Input(Direct.Right);
		}else if(Input.GetKey(KeyCode.Space)){
			VGame.SceneManager.Input(Direct.Jump);
		}else if(Input.GetKey(KeyCode.B)){
			VGame.SceneManager.Input(Direct.Attack);
		}

	}
}


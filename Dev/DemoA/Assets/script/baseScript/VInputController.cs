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
		if(Input.GetKey(KeyCode.W)){
			VGame.SceneManager.Input(Direct.Up);
		}else if(Input.GetKey(KeyCode.S)){
			VGame.SceneManager.Input(Direct.Down);
		}else if(Input.GetKey(KeyCode.A)){
			VGame.SceneManager.Input(Direct.Left);
		}else if(Input.GetKey(KeyCode.D)){
			VGame.SceneManager.Input(Direct.Right);
		}else if(Input.GetKey(KeyCode.Space)){
			VGame.SceneManager.Input(Direct.Jump);
		}else if(Input.GetKeyDown(KeyCode.J)){
			VGame.SceneManager.Input(Direct.Attack);
		}

	}
}


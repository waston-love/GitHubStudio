using UnityEngine;
using System.Collections;

public class VUILoading : VUIBase 
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

	}
	

}

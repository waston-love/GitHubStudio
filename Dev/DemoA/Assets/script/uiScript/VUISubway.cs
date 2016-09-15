using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class VUISubway : VUIBase
{
	private Dictionary<int,Transform> _Stage = new Dictionary<int, Transform>();

	public VUISubway ()
	{

	}


	public override void OnOpen(params object[] args)
	{
		this.gameObject.SetActive(true);

		VRepresent.UIManager.CloseWindow<VUIMainMenu>();
	}
	
	public override void OnClose()
	{
		this.gameObject.SetActive(false);        
	}
	
	
	public override void OnInit()
	{
		EventDelegate.Add(FindControl<UIButton>("BtnReturn").onClick,this._ClickReturn);

		foreach(int id in VGame.Instance.StageTemManager.StageSetting.Keys){
			Transform st = FindControl<Transform>("BtnStage"+id.ToString());
			this._Stage.Add(id,st);
			UIEventListener lis = st.GetComponent<UIEventListener>();
			if(lis == null)
				lis = st.gameObject.AddComponent<UIEventListener>();
			lis.onClick += this.ClickStage;

			VStageInfo info = VGame.Instance.StageTemManager.StageSetting[id];
			st.GetChild(0).GetComponent<UILabel>().text = info.Name;
		}

	}

	public void Refresh(){

	}
	
	
	#region ui event
	private void _ClickReturn(){
		VRepresent.UIManager.OpenWindow<VUIMainMenu>();
		this.OnClose();
	}

	private void ClickStage(GameObject go){
		int stageId = int.Parse(go.name.Substring(8,1));
		VGame.SceneManager.StartGame(stageId);
		this.OnClose();

	
	}
	#endregion
}

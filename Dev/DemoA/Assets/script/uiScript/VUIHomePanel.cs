using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VUIHomePanel : VUIBase 
{
	private HomeType _HomeType;
	private Transform _BuildPanel;
	private Transform _ProductPanel;
	private Transform _ShopPanel;
	private List<Transform> _IcoList = new List<Transform>();
	private UIGrid _Grid;

	private Transform _BoxIcon;

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
		EventDelegate.Add(FindControl<UIButton>("BtnBuild").onClick,this._ClickBuild);
		EventDelegate.Add(FindControl<UIButton>("BtnProduct").onClick,this._ClickProduct);
		EventDelegate.Add(FindControl<UIButton>("BtnShop").onClick,this._ClickShop);

		_BuildPanel = FindControl<Transform>("BuildPanel");
	
		_BoxIcon = FindControl<Transform>("BoxIcon");

		_Grid = FindControl<UIGrid>("Grid");
	}

	#region ui event
	private void _ClickBuild(){
		SwitchPanel(HomeType.Build);
	}
	private void _ClickProduct(){
		SwitchPanel(HomeType.Product);
	}
	private void _ClickShop(){
		SwitchPanel(HomeType.Shop);
	}
	#endregion

	private void SwitchPanel(HomeType type){
		_HomeType = type;

		_BuildPanel.gameObject.SetActive(false);
	
		if(_HomeType == HomeType.Build){
			OpenShopPanel(VGame.Instance.HouseManager.BuildSystem.ShopTable);
		}else if(_HomeType == HomeType.Product){
			OpenShopPanel(VGame.Instance.HouseManager.ProductSystem.ShopTable);
		}else if(_HomeType == HomeType.Shop){
			OpenShopPanel(VGame.Instance.HouseManager.ShopSystem.ShopTable);
		}
	}

	private void OpenShopPanel(Dictionary<int,VShopAttribute> shopTable){
		this._BuildPanel.gameObject.SetActive(true);
		for(int i=this._IcoList.Count-1;i>=0;i--){
			_Grid.RemoveChild(this._IcoList[i]);
			UnityEngine.Object.Destroy(this._IcoList[i].gameObject);
		}
		_IcoList.Clear();
		_Grid.repositionNow = true;
		
		foreach(VShopAttribute att in shopTable.Values){		
			GameObject icon = UnityEngine.Object.Instantiate(_BoxIcon.gameObject);			
			
			icon.SetActive(true);
			icon.transform.parent = this.transform;
			icon.transform.localScale = Vector3.one;
			icon.transform.name = att.Id.ToString();
			icon.transform.FindChild("Name").GetComponent<UILabel>().text = att.Name;
			
			for(int i=0;i<att.Cost.Count;i++){
				icon.transform.FindChild("Cost"+(i+1).ToString()).GetComponent<UILabel>().text = att.Cost[i].x + "  " + att.Cost[i].y;
				icon.transform.FindChild("Cost"+(i+1).ToString()).gameObject.SetActive(true);
			}
			
			this._IcoList.Add(icon.transform);
			this._Grid.AddChild(icon.transform);
		}
	}
}

public enum HomeType : ushort{
	Build = 0,
	Product = 1,
	Shop = 2,
}
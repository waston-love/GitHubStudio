using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShopSystem
{
	public ShopSystem ()
	{
	}

	public int Id;
	public string Name;

	private string TabPath;

	public Dictionary<int,VShopAttribute> ShopTable = new Dictionary<int, VShopAttribute>();

	public void Init(string path){
		TabPath = path;
		LoadShopAttribute();
	}

	
	void LoadShopAttribute()
	{

		VTabFile tab = new VTabFile(TabPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VShopAttribute attribute = new VShopAttribute();
			attribute.Id = tab.GetInteger(row, "Id");
			attribute.Name = tab.GetString(row, "Name");
			attribute.Max = tab.GetInteger(row, "Max");

			for(int i=1;i<=3;i++){
				string cost = tab.GetString(row, "Cost" + i.ToString());
				if(cost.Equals("0"))
					continue;
				if(cost.Contains("|")){
					string[] type = cost.Split('|');
					Vector2 c = new Vector2(float.Parse(type[0]),float.Parse(type[1]));
					attribute.Cost.Add(c);
				}
			}
			ShopTable.Add(attribute.Id,attribute);
		}
	}
}

public class VShopAttribute{
	public int Id;
	public string Name;
	public List<Vector2> Cost = new List<Vector2>();
	public int Max;
}
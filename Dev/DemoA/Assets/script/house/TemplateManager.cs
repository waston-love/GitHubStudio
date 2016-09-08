using System;
using System.Collections;
using System.Collections.Generic;

public class TemplateManager
{
	public Dictionary<int,VSprites> Building = new Dictionary<int, VSprites>();
	public Dictionary<int,VSprites> Thing = new Dictionary<int, VSprites>();

	public string BuildingPath;
	public string ThingPath;

	public TemplateManager ()
	{
	}

	public void Init(string bp,string tp){
		BuildingPath = bp;
		ThingPath = tp;

		LoadBuilding();
		LoadThing();
	}

	
	void LoadBuilding()
	{
		
		VTabFile tab = new VTabFile(ThingPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VSprites sp = new VSprites();
			sp.Id = tab.GetInteger(row, "Id");
			sp.ResName = tab.GetString(row, "ResName");
			sp.Name = tab.GetString(row, "Name");
			
			Building.Add(sp.Id,sp);
		}
	}
	void LoadThing()
	{
		
		VTabFile tab = new VTabFile(BuildingPath);
		int height = tab.GetHeight();
		
		for (int row = 2; row <= height; row++)
		{
			VSprites sp = new VSprites();
			sp.Id = tab.GetInteger(row, "Id");
			sp.ResName = tab.GetString(row, "ResName");
			sp.Name = tab.GetString(row, "Name");
			
			Thing.Add(sp.Id,sp);
		}
	}

}

public class VSprites{
	public int Id;
	public string ResName;
	public string Name;
}


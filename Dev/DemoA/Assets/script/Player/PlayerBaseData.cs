
using System;

public class PlayerBaseData
{
	public PlayerBaseData ()
	{
	}

	private string _Name;
	private int _Age;
	private int _Score;

	public void Init(string name,int age, int score){
		_Name = name;
		_Age = age;
		_Score = score;
	}

	public string Name{
		get{
			return this._Name;
		}
		set{
			this._Name = value;
		}
	}
	public int Age{
		get{
			return this._Age;
		}
		set{
			this._Age = value;
		}
	}
	
	public int Score{
		get{
			return this._Score;
		}
	}


}
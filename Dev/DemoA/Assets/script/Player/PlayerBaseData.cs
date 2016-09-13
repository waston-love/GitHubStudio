
using System;

public class PlayerBaseData
{
	public PlayerBaseData ()
	{
	}

	private string _Name;
	private int _Age;
	private int _Score;
	private int _HeroId;

	public void Init(string name,int age, int score,int heroId){
		_Name = name;
		_Age = age;
		_Score = score;
		_HeroId = heroId;
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

	public int HeroId{
		get{
			return this._HeroId;
		}
		set{
			this._HeroId = value;
		}
	}


}
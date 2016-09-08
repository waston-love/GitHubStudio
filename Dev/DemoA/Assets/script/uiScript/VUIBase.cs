using UnityEngine;
using System.Collections;

public class VUIBase : MonoBehaviour {

	public string UIName = "";
	
	public virtual void OnOpen(params object[] args)
	{ 
		
	}
	
	public virtual void OnClose()
	{ 
		
	}
	
	public virtual void OnInit()
	{ 
		
	}

	
	public T FindControl<T>(string name) where T : Component
	{
		GameObject obj = DFSFindObject(transform, name);
		if (obj == null)
			return null;
		
		return obj.GetComponent<T>();
	}

	
	public GameObject DFSFindObject(Transform parent, string name)
	{
		for (int i = 0; i < parent.childCount; ++i)
		{
			Transform node = parent.GetChild(i);
			if (node.name == name)
				return node.gameObject;
			
			GameObject target = DFSFindObject(node, name);
			if (target != null)
				return target;
		}
		
		return null;
	}
}

using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour 
{
	[HideInInspector]
	public static FXManager instance;

	public GameObject[] fxList;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}	

	public GameObject SpawnFX(string name, Vector3 position, Quaternion rotation)
	{
		foreach(GameObject fx in fxList)
		{
			if(fx.name == name)
			{
				GameObject newFX = Instantiate(fx, position, rotation) as GameObject;

				return newFX;
			}
		}

		Debug.Log("fx: " + name + " not found.");
		return null;
	}
}

using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour 
{
	// singleton
	[HideInInspector]
	public static WeaponManager instance;

	public GameObject[] weaponList;

	// Use this for initialization
	void Awake () 
	{
		instance = this;
	}

	public GameObject RequestWeapon(string name)
	{
		foreach(GameObject weapon in weaponList)
		{
			if(weapon.name == name)
			{
				GameObject newWeapon = Instantiate(weapon) as GameObject;
				
				return newWeapon;
			}
		}
		
		Debug.Log("weapon: " + name + " not found.");
		return null;
	}

}

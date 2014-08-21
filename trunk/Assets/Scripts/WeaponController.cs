using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{

	public Transform handTransform;
	public string defaultWeapon;

	private Weapon currentWeapon;

	// Use this for initialization
	void Start()
	{
		Screen.lockCursor = true;
		SwitchWeapon(defaultWeapon);
	}
	
	// Update is called once per frame
	void Update()
	{
		// Check for a weapon
		if(currentWeapon != null)
		{
			// Check if "fire" is pressed
			if(Input.GetButtonDown("Fire1"))
			{
				// Fire the weapon
				currentWeapon.Fire();
			}
		}
	}

	void SwitchWeapon(string name)
	{
		// Check if current weapon is not null
		if(currentWeapon != null)
		{
			// Separate from any parent
			currentWeapon.transform.parent = null;

			// Destroy current weapon
			Destroy(currentWeapon.gameObject);
		}

		// Get new weapon
		GameObject weapon = WeaponManager.instance.RequestWeapon(name);

		// Check weapon validity
		if(weapon != null)
		{
			// Attach weapon to a new parent
			weapon.transform.parent = handTransform;
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;

			// Reassign value of currentWeapon
			currentWeapon = weapon.GetComponent<Weapon>();
		}
	}
}

using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{

	public Transform handTransform;
	public string defaultWeapon;

	private Weapon currentWeapon;

	private float scrollSensitivity;
	private float scrollValue;

	private GameObject newWeapon;

	private int weaponIndex;

	// Use this for initialization
	void Start()
	{
		Screen.lockCursor = true;
		SwitchWeapon(defaultWeapon);

		scrollSensitivity = 0.5f;

		scrollValue = 0;

		weaponIndex = 0;

		GunShot boom = GetComponent<GunShot>();
	}
	
	// Update is called once per frame
	void Update()
	{
		scrollValue = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

		// Check for a weapon
		if(currentWeapon != null)
		{
			// Check if "fire" is pressed
			if(Input.GetButtonDown("Fire1"))
			{
				// Fire the weapon
				currentWeapon.Fire();



			}

			// Switch weapons as the mouse wheel scrolls
			if(scrollValue > 0.0f || scrollValue < 0.0f)
			{
				// Check the current position in the weaponList array and reset to 0 if index reaches upper bounds
				if(weaponIndex >= WeaponManager.instance.weaponList.GetUpperBound(0))
				{
					weaponIndex = 0;
				}
				else
				{
					weaponIndex++;
				}

				// Switch to next weapon in the array
				newWeapon = WeaponManager.instance.weaponList[weaponIndex];

				SwitchWeapon(newWeapon.name);
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

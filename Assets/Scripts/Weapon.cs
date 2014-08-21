using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public float damageAmount;
	public float range;

	public abstract void Fire();

	protected void DealDamage(Health health)
	{
		// Deal damage
		health.TakeDamage(damageAmount);

		// Check for death
		if(!health.IsAlive())
		{
			Destroy(health.gameObject);
		}

	}
}

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{

	public float maxHealth;
	public string hitFX;

	private float currentHealth;

	// Use this for initialization
	void Start()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;
	}

	public bool IsAlive()
	{
		return(currentHealth > 0.0f);
	}

	public string GetHitFX()
	{
		return hitFX;
	}
}

using UnityEngine;
using System.Collections;

public class Rifle: Weapon {
	
	public override void Fire()
	{
		
		Transform cameraTransform = Camera.main.transform;	// Transform of the main Camera
		Ray testRay = new Ray(cameraTransform.position, cameraTransform.forward);	// Ray cast from the pos of the main camera
		RaycastHit hitInfo = new RaycastHit();	// Info on the impact point of the Ray
		
		// Check if the Ray has hit a target
		if(Physics.Raycast(testRay, out hitInfo, range))
		{
			// Get info on the health of the target that has been hit
			Health health = hitInfo.transform.GetComponent<Health>();
			if(health != null)
			{
				// Spawn visual effect
				Vector3 pos = hitInfo.point;
				Quaternion rot = Quaternion.identity;
				FXManager.instance.SpawnFX(health.GetHitFX(), pos, rot);
				
				DealDamage(health);
			}
		}


	}
}


using UnityEngine;
using System.Collections;

public class SubMachineGun : Weapon 
{
	public Transform muzzleTransform;

	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;
		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);

		RaycastHit hitInfo = new RaycastHit ();
		if( Physics.Raycast(ray, out hitInfo, range))
		{
			//Its a hit!
			Health health = hitInfo.collider.GetComponentInParent<Health> ();
			if(health)
			{
				//hit
				hitInfo.rigidbody.AddExplosionForce(10f, hitInfo.point ,1f);
				health.TakeDamage(damage);
				VFXManager.Instance.Spawn("BloodSplatter", hitInfo.point , Quaternion.identity );
			}
			else
			{
				//not hit -- spawn dust
				Quaternion rot = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
				VFXManager.Instance.Spawn("Dust", hitInfo.point, rot);
			}
		}

		coolDown = fireRate;
		VFXManager.Instance.Spawn("MuzzleFlare", muzzleTransform.position, muzzleTransform.rotation);
	}
}

using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	Weapon currentWeapon;
	public GameObject Hand;

	// Use this for initialization
	void Start () 
	{
		SwitchWeapon("HandGun");
		currentWeapon = GetComponentInChildren< Weapon > ();
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentWeapon.IsAuto())
		{
			if (Input.GetButton("Fire1"))
			{
				currentWeapon.Fire();
			}
		}
		else
		{
			if (Input.GetButtonDown("Fire1"))
			{
				currentWeapon.Fire();
			}
		}

		//Weapon Switch Buttons
		if (Input.GetKeyDown ("1"))
		{
			
			SwitchWeapon("HandGun");
			
		}
		else if (Input.GetKeyDown ("2"))
		{
			
			SwitchWeapon("SubMachineGun");
			
		}
	}

	//Weapon Switch Code
	void SwitchWeapon (string name)
	{
		if (currentWeapon) 
		{
			currentWeapon.transform.parent = null;
			Destroy(currentWeapon.gameObject);
		}
		
		GameObject gun = GunManager.Instance.SpawnGun (name, Hand.transform.position, Hand.transform.rotation);
		if (gun)
		{
			//platform = collision.gameObject;
			gun.transform.parent = Hand.transform;
			currentWeapon = gun.GetComponent<Weapon> ();
		}
	}
}

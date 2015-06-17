using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour 
{

	public GameObject[] Guns;
	static public GunManager Instance;
	

	
	void Awake () 
	{
		Instance = this;
	}

	//Obtaining New Weapon
	public GameObject SpawnGun(string name, Vector3 position, Quaternion rotation)
	{
		//Weapon Switching Code
		foreach (GameObject gun in Guns)
		{
			if(gun.name == name)
			{
				return Instantiate (gun, position, rotation) as GameObject;
			}
		}
		return null;
	}

	
}

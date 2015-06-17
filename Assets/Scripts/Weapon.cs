using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour 
{
	public float coolDown;
	public int damage;
	public float range;
	public float fireRate;
	public bool isAuto;
	
	void Update()
	{
		coolDown -= Time.deltaTime;
	}
	
	public bool IsAuto()
	{
		return isAuto;
	}
	
	public bool IsReady()
	{
		return (coolDown <= 0f);
	}

	public abstract void Fire();
}

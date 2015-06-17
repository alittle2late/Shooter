using UnityEngine;
using System.Collections;

public class DestroyParticleSystemOnFinish : MonoBehaviour 
{
	ParticleSystem ps;

	void Start () 
	{
		ps = GetComponent<ParticleSystem>();

	}
	
	void LateUpdate () 
	{
		if ( !ps.IsAlive() )
		{
			Destroy(gameObject);
		}
	}
}

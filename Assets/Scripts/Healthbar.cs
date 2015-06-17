using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {

	public static Healthbar Living;

	public static bool isAlive = true;
	
	public float maxHealth;
	public float curHealth;
	
	public float healthBarLength;

	void Awake()
	{
		Living = this;
	}

	void Start () 
	{
		healthBarLength = Screen.width / 2;
	}
	
	void Update () 
	{
		AddjustCurrentHealth (0) ;
	}

	void OnGUI ()
	{
		GUI.color = Color.white;
		GUI.backgroundColor = Color.green;
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup( new Rect( 0, 0, healthBarLength, 32 ) );
		
		// Draw the background image
		GUI.Button( new Rect( 0, 0, healthBarLength, 32 ), "Health");
		
		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup( new Rect( 0, 0, curHealth / maxHealth * healthBarLength, 32 ) );
		
		// Draw the foreground image
		//GUI.Box( new Rect( 0, 0, healthBarLength, 32 ), "" );
		
		// End both Groups
		GUI.EndGroup();
		
		GUI.EndGroup();
	}

	public void AddjustCurrentHealth( int adj )
	{
		
		curHealth += adj;
		
		if( curHealth < 0 )
			curHealth = 0;
		
		if( curHealth > maxHealth )
			curHealth = maxHealth;
		
		if( maxHealth < 1 )
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}

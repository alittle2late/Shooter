using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouWin : MonoBehaviour {

	public float restartDelay = 5f; 
	float restartTimer;
	
	void Update () 
	{
		if (GameObject.Find ("Zombie") == null) {
						GetComponent<Text> ().text = "You Win!";
						/*GameObject hb = GameObject.Find( "HealthBar" );
			if( hb )
			{
				HealthBar HealthBar = hb.GetComponent<HealthBar>();
				HealthBar.curHealth += 100;
			}
			
			restartTimer += Time.deltaTime;
			
			if( restartTimer >= restartDelay )
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel( Application.loadedLevel );
			}*/
				} 
		else 
		{
			GetComponent<Text> ().text = "";
		}

	}
}

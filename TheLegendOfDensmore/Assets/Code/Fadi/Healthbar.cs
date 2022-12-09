using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
	public Scrollbar health;
	public PlayerStatus player; 
   	double health_max = -1;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
		GameObject cam = GameObject.Find("Main Camera");
		if(cam.name != "Main Camera") return;
		player = (PlayerStatus)cam.GetComponent(typeof(PlayerStatus));
		player = cam.GetComponent<PlayerStatus>();
		if(health_max == -1){
			health_max = player.player_health;
		}
		
        health.size = (float)(player.player_health/health_max);
    }
}

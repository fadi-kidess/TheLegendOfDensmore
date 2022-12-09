using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
	public Scrollbar health;
	PlayerStatus player_status; 
	Boss boss_code;
	public GameObject player;
	public bool is_boss;
	public GameObject boss;
   	double health_max = -1;
    // Start is called before the first frame update
    // Update is called once per frame
	void Start()
	{
		if(!is_boss){
			player_status = player.GetComponent<PlayerStatus>();
			health_max = player_status.player_health;
		}else{
			boss_code = boss.GetComponent<Boss>();
			health_max = boss_code.health;
		}
	}
    void Update()
    {
		
		if(!is_boss){
			print(health_max);
        	health.size = (float)(player_status.player_health/health_max);
		}else{
			health.size = (float)( boss_code.health/health_max);
		}
    }
}

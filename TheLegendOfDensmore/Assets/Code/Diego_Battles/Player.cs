using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    enum PlayerState
    {
        STILL_ALIVE,
        NOW_DEAD
    };

   public double player_health;
   public int player_damage;
    PlayerState player_state;
    //int evade;
   // int crit;
   // double health_loss;
   // int block;
    // Start is called before the first frame update
    void Start()
    {
        player_state = PlayerState.STILL_ALIVE;
        player_health = 50;
        player_damage = 15;
        print("Player has entered the dungeon");
    }

    // Update is called once per frame
    void Update()
    {
        if(player_health <= 0)
        {
            player_state = PlayerState.NOW_DEAD;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public:

    enum PlayerState
    {
        STILL_ALIVE,
        NOW_DEAD
    };

    double player_health;
    int player_damage;
    Player player_state;
    //int evade;
   // int crit;
   // double health_loss;
   // int block;
    // Start is called before the first frame update
    void Start()
    {
        player_state = PlayerState.STILL_ALIVE;
        player_health = 50;
        Player_damage = 15;
        printf("Player has entered the dungeon");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.player_health <= 0)
        {
            player_state = PlayerState.NOW_DEAD;
        }
    }
}

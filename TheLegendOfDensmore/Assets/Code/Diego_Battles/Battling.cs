using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battling : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Player1;
    public GameObject choice;
    public int num_enemies;
    bool enemy1_block;
    bool enemy2_block;
    bool enemy3_block; //used for to store the state of if the enemy is blocking or not
    
    // Start is called before the first frame update
    void Start()
    {
        num_enemies = 0;
        print("You started battling");
        if(Enemy1.activeSelf)
        {
            num_enemies++;
        }
        if(Enemy2.activeSelf)
        {
            num_enemies++;
        }
        if(Enemy3.activeSelf)
        {
            num_enemies++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(num_enemies) 
        {
            case 3:
            {
              if(Player1.GetComponent<PlayerStatus>().player_state == PlayerStatus.PlayerState.PLAYER_ALIVE && ((Enemy1.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE) || (Enemy2.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE) || (Enemy3.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE)))
                {
                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                        
                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {

                    }
                    else
                    {
                        return;
                    }
                }
                break;
            }

            case 2:
            {
                if(Player1.GetComponent<PlayerStatus>().player_state == PlayerStatus.PlayerState.PLAYER_ALIVE && ((Enemy1.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE) || (Enemy2.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE)))
                {
                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                
                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend 
                    { 

                    }
                    else
                    {
                        return;
                    }
                }
                break;
            }

            case 1:
            {
                if(Player1.GetComponent<PlayerStatus>().player_state == PlayerStatus.PlayerState.PLAYER_ALIVE && (Enemy1.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE))
                {
                    enemy1_block = IsBlocking(); //stores the state of if the enemy is blocking or attacking

                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                        if(DoesCrit()) //if the player lands a crit
                        {
                            if(enemy1_block) //if the enemy is blocking while the player crits
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= Player1.GetComponent<PlayerStatus>().player_damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (Player1.GetComponent<PlayerStatus>().player_damage * 2); //if not blocking, the enemy receives 2x damage
                            }
                        }
                        else //non crit attack
                        {
                             if(enemy1_block) //if the enemy is blocking 
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (Player1.GetComponent<PlayerStatus>().player_damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= Player1.GetComponent<PlayerStatus>().player_damage; //if not blocking, the enemy receives normal damage
                            }
                        }

                    if(enemy1_block)
                    {
                        Player1.GetComponent<PlayerStatus>().player_health = Player1.GetComponent<PlayerStatus>().player_health; //if the enemy is blocking, health does not change 
                    }
                    else
                    {
                        Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage; //player takes set damage from enemy if the enemy isn't blocking
                    }

                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {
                        if(enemy1_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health = Player1.GetComponent<PlayerStatus>().player_health; //if the enemy is blocking, health does not change 
                        }
                        else
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                break;
            }
        }
        //Enemy1.GetComponent<Enemy>().enemy_health
        
    }

    bool DoesCrit() //used to see if the player randomly does a critical damage attack to do 2x damage
    {
        return true;
    }

    bool DoesDodge() //used to see if the player "dodges" the attack and avoids all damage
    {
        return true;
    }

    bool IsBlocking() //used to see if an enemy blocks the attack and only takes half damage
    {
        return true;
    }
}

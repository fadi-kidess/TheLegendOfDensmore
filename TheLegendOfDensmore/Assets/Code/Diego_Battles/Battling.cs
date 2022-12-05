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
    bool player_block; //used to make a multiplier for when the player blocks
    
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
                    enemy1_block = IsBlocking(); //stores the state of if the enemy is blocking or attacking
                    enemy2_block = IsBlocking();
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

                            if(enemy2_block) //repeat process but for enemy 2
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= Player1.GetComponent<PlayerStatus>().player_damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (Player1.GetComponent<PlayerStatus>().player_damage * 2); //if not blocking, the enemy receives 2x damage
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

                             if(enemy2_block) //if the enemy is blocking 
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (Player1.GetComponent<PlayerStatus>().player_damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= Player1.GetComponent<PlayerStatus>().player_damage; //if not blocking, the enemy receives normal damage
                            }
                        }
                    //enemy turn to attack player
                    if(enemy1_block && enemy2_block) //both enemies but block for the player to receive no damage
                    {
                        Player1.GetComponent<PlayerStatus>().player_health = Player1.GetComponent<PlayerStatus>().player_health; //if the enemy is blocking, health does not change 
                    }
                    else if(enemy1_block) //only enemy 2 is attacking
                    {
                        Player1.GetComponent<PlayerStatus>().player_health -= Enemy2.GetComponent<Enemy>().enemy_damage;
                    }
                    else if(enemy2_block) //only enemy 1 is attacking
                    {
                        Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage;
                    }
                    else
                    {
                        Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage); //player takes set damage from both enemies if the enemy isn't blocking
                    }

                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {
                        if(enemy1_block && enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health = Player1.GetComponent<PlayerStatus>().player_health; //if the enemy is blocking, health does not change 
                        }
                        else if(enemy1_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy2.GetComponent<Enemy>().enemy_damage;
                        }
                        else if(enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage;
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
                    //enemy turn to hurt the player
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
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage / 2); //if player defends, only takes half damage
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
        return;
    }

    bool DoesCrit() //used to see if the player randomly does a critical damage attack to do 2x damage
    {
        int crit_chance = Random.Range(1, 100);
        if(crit_chance <= 5) //5% chance to crit
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    bool DoesDodge() //used to see if the player "dodges" the attack and avoids all damage
    {
        int dodge_chance = Random.Range(1, 100);
        if(dodge_chance <= 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsBlocking() //used to see if an enemy blocks the attack and only takes half damage
    {
        int block_chance = Random.Range(1, 100);
        if(block_chance <= 35) //35% chance for the enemy to block
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

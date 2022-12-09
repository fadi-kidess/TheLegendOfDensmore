using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battling : MonoBehaviour //must add break statements to the multi-enemy attacks so that the heirarchy of attacks dont stack and so that dodge mechanism can be implemented
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
    bool player_evade;
    double block_damage;
    double base_damage;
    public double damage;
    


//player.getcomp.damage replace with damage

//if player_block == true, damage = block damage else 



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
        if(num_enemies > 0) //may need to examine on thursday in case battle does not occur
        {
            block_damage = Player1.GetComponent<PlayerStatus>().player_damage * 1.25;
            base_damage = Player1.GetComponent<PlayerStatus>().player_damage;
            damage = base_damage;
            choice.GetComponent<TextChoice>().reset();
        }
    }

    // Update is called once per frame
    void Update()
    {


        if(player_block)
        {
            damage = block_damage;
        }
        else
        {
            damage = base_damage;
        }

        

        switch(num_enemies) 
        {
            case 3:
            {
              if(Player1.GetComponent<PlayerStatus>().player_state == PlayerStatus.PlayerState.PLAYER_ALIVE && ((Enemy1.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE) || (Enemy2.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE) || (Enemy3.GetComponent<Enemy>().enemy_state == Enemy.EnemyState.ALIVE)))
                {
                    enemy1_block = IsBlocking(); //stores the state of if the enemy is blocking or attacking
                    enemy2_block = IsBlocking();
                    enemy3_block = IsBlocking();
                    player_evade = DoesDodge();

                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                        print("HELLO******");
                        if(DoesCrit()) //if the player lands a crit
                        {
                            if(enemy1_block) //if the enemy is blocking while the player crits
                            {
                                print("THE ENEMY IS BLOCKING****");
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage * 2); //if not blocking, the enemy receives 2x damage
                            }

                            if(enemy2_block) //repeat process but for enemy 2
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (damage * 2); //if not blocking, the enemy receives 2x damage
                            }

                            if(enemy3_block)
                            {
                                Enemy3.GetComponent<Enemy>().enemy_health -= damage;
                            }
                            else
                            {
                                Enemy3.GetComponent<Enemy>().enemy_health -= (damage * 2);
                            }

                        }
                        else //non crit attack
                        {
                            if(enemy1_block) //if the enemy is blocking 
                            {
                                print ("THE ATTACK LANDED*****");
                                print (Enemy1.name);
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            }

                            if(enemy2_block) //if the enemy is blocking 
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            } 

                            if(enemy3_block) //if the enemy is blocking 
                            {
                                Enemy3.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy3.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            } 
                        } 
                     //enemy turn to attack player
                        if(player_evade)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health += 0;
                        }
                        if(enemy1_block && enemy2_block && enemy3_block) //both enemies but block for the player to receive no damage
                        {
                            Player1.GetComponent<PlayerStatus>().player_health += 0;
                        }   
                        else if(enemy1_block && enemy3_block) //only enemy 2 is attacking
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy2.GetComponent<Enemy>().enemy_damage;
                        }
                        else if(enemy2_block && enemy3_block) //only enemy 1 is attacking
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage;
                        }
                        else if(enemy1_block && enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= Enemy3.GetComponent<Enemy>().enemy_damage;
                        }
                        else if(enemy1_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy3.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage); //only enemy 1 blocks
                        }
                        else if(enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy3.GetComponent<Enemy>().enemy_damage + Enemy1.GetComponent<Enemy>().enemy_damage); //only enemy 2 blocks
                        }
                        else if(enemy3_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage); //only enemy 3 blocks
                        }
                        else
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage + Enemy3.GetComponent<Enemy>().enemy_damage); //player takes set damage from all enemies if the enemy isn't blocking
                        }

                        player_block = false;
                        choice.GetComponent<TextChoice>().reset();
                    }
                    
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {
                        if(enemy1_block && enemy2_block && enemy3_block) //both enemies but block for the player to receive no damage
                        {
                            Player1.GetComponent<PlayerStatus>().player_health += 0;
                        }   
                        else if(enemy1_block && enemy3_block) //only enemy 2 is attacking
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy2.GetComponent<Enemy>().enemy_damage / 2);
                        }
                        else if(enemy2_block && enemy3_block) //only enemy 1 is attacking
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage / 2);
                        }
                        else if(enemy1_block && enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy3.GetComponent<Enemy>().enemy_damage / 2);
                        }
                        else if(enemy1_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= ((Enemy3.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage) / 2); //only enemy 1 blocks
                        }
                        else if(enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= ((Enemy3.GetComponent<Enemy>().enemy_damage + Enemy1.GetComponent<Enemy>().enemy_damage) / 2); //only enemy 2 blocks
                        }
                        else if(enemy3_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= ((Enemy1.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage) / 2); //only enemy 3 blocks
                        }
                        else
                        {
                            Player1.GetComponent<PlayerStatus>().player_health -= ((Enemy1.GetComponent<Enemy>().enemy_damage + Enemy2.GetComponent<Enemy>().enemy_damage + Enemy3.GetComponent<Enemy>().enemy_damage) / 2); //player takes set damage from all enemies if the enemy isn't blocking
                        }

                        player_block = true;
                        choice.GetComponent<TextChoice>().reset();
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
                    player_evade = DoesDodge();
                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                        if(DoesCrit()) //if the player lands a crit
                        {
                            if(enemy1_block) //if the enemy is blocking while the player crits
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage * 2); //if not blocking, the enemy receives 2x damage
                            }

                            if(enemy2_block) //repeat process but for enemy 2
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (damage * 2); //if not blocking, the enemy receives 2x damage
                            }
                        }
                        else //non crit attack
                        {
                            if(enemy1_block) //if the enemy is blocking 
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            }

                             if(enemy2_block) //if the enemy is blocking 
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy2.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            }
                        }
                    //enemy turn to attack player
                    if(player_evade)
                    {
                        Player1.GetComponent<PlayerStatus>().player_health += 0;
                    }
                    if(enemy1_block && enemy2_block) //both enemies but block for the player to receive no damage
                    {
                        Player1.GetComponent<PlayerStatus>().player_health += 0;
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

                    player_block = false;
                    choice.GetComponent<TextChoice>().reset();

                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {
                        if(enemy1_block && enemy2_block)
                        {
                            Player1.GetComponent<PlayerStatus>().player_health += 0; //nothing happens to health
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

                        player_block = true;
                        choice.GetComponent<TextChoice>().reset();
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
                    player_evade = DoesDodge();

                    if(choice.GetComponent<TextChoice>().choice() == 1) //battles
                    {
                        print("Player is attacking");
                        if(DoesCrit()) //if the player lands a crit
                        {
                            print("Player landed a crit");
                            if(enemy1_block) //if the enemy is blocking while the player crits
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //half damage * 2x mulitply cancels out
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage * 2); //if not blocking, the enemy receives 2x damage
                            }
                        }
                        else //non crit attack
                        {
                            print("no crit");
                             if(enemy1_block) //if the enemy is blocking 
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= (damage / 2); //half damage because the enemy is blocking
                            }
                            else
                            {
                                Enemy1.GetComponent<Enemy>().enemy_health -= damage; //if not blocking, the enemy receives normal damage
                            }
                        }
                    //enemy turn to hurt the player
                    if(player_evade)
                    {
                        print("Player dodged");
                    }
                    if(enemy1_block)
                    {
                        print("enemy is blocking");
                    }
                    else
                    {
                        print("enemy hurt player");
                        Player1.GetComponent<PlayerStatus>().player_health -= Enemy1.GetComponent<Enemy>().enemy_damage; //player takes set damage from enemy if the enemy isn't blocking
                    }
                    player_block = false;
                    choice.GetComponent<TextChoice>().reset();

                    }
                    else if(choice.GetComponent<TextChoice>().choice() == 2) //defend
                    {
                        if(enemy1_block)
                        {
                           print("both are blocking");
                        }
                        else
                        {
                            print("enemy is attacking player");
                            Player1.GetComponent<PlayerStatus>().player_health -= (Enemy1.GetComponent<Enemy>().enemy_damage / 2); //if player defends, only takes half damage
                        }

                        player_block = true;
                       choice.GetComponent<TextChoice>().reset();
                    }

                    else
                    {
                        return;
                    }
                // if(Enemy1.activeSelf == false)
                // {
                //     choice.GetComponent<TextChoice>().deactivate();
                // }
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

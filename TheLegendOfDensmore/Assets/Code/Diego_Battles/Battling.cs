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
        }
        //Enemy1.GetComponent<Enemy>().enemy_health
        
    }

    bool DoesCrit()
    {

        return true;
    }
}

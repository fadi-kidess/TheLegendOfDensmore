using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
public enum EnemyState
    {
        DEAD,
        ALIVE
    };

  public  double enemy_health;
  public  int enemy_damage;
   // double health_loss; Probably used in the battling function but added here just in case
   // int block; same as above
    public EnemyState enemy_state;
  public  int level;
  public  int lvl_lowerbound; //used for the random number generator of what level the enemy is; used for scaling enemies proportionally to the distance from the first room
  public  int lvl_upperbound; //same as above 


    

    int GetEnemyLevel()
    {
        //Random rnd = new Random();
        int enemy_lvl = Random.Range(1, 3); //subject to change when enemy scaling is coded
        return enemy_lvl;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy_state = EnemyState.ALIVE;
        level = GetEnemyLevel();
        switch (level)
        {
            case 1:
            {
                enemy_health = 10;
                enemy_damage = 3;
                print("Level 1 enemy appeared!");
                break;
            }

            case 2:
            {
                enemy_health = 12;
                enemy_damage = 5;
                print("Level 2 enemy appeared!");
                break;
            }

            case 3:
            {
                enemy_health = 15;
                enemy_damage = 7;
                print("Level 3 enemy appeared!");
                break;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_health <= 0)
        {
            enemy_state = EnemyState.DEAD;
            enemy_damage = 0;
            gameObject.SetActive(false);
        }
    }
}

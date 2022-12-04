using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public:
    enum EnemyState
    {
        DEAD,
        ALIVE
    };

    double enemy_health;
    int enemy_damage;
   // double health_loss; Probably used in the battling function but added here just in case
   // int block; same as above
    Enemy enemy_state;
    int level;


    

    int GetEnemyLevel()
    {
        Random rnd = new Random();
        int enemy_lvl = rnd.Next(1,3);
        return enemy_lvl;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy_state = EnemyState.ALIVE;
        level = Enemy.GetEnemyLevel();
        switch level
        {
            case 1:
            {
                enemy_health = 15;
                enemy_damage = 5;
                printf("Level 1 enemy appeared!");
                break;
            }

            case 2:
            {
                enemy_health = 20;
                enemy_damage = 7;
                printf("Level 2 enemy appeared!");
                break;
            }

            case 3:
            {
                enemy_health = 25;
                enemy_damage = 15;
                printf("Level 3 enemy appeared!");
                break;
            }

            default:
            {
                printf("unknown error fix something");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.enemy_health <= 0)
        {
            enemy_state = EnemyState.DEAD;
        }
    }
}

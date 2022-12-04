using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battling : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Player1;
    int num_enemies;
    // Start is called before the first frame update
    void Start()
    {
        print("You started battling");
        num_enemies = 0;
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
        //if(Enemy1.activeself)
        {
            num_enemies++;
        }
        //Enemy1.GetComponent<Enemy>().enemy_health
    }
}

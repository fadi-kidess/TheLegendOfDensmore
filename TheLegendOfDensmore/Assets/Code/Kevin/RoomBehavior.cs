using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoomBehavior : MonoBehaviour
{
    public GameObject Triangle;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

public enum RoomState
    {
        COMPLETED,
        UNCOMPLETED,
        UNDISCOVERED,
        DISCOVERED
    };

public RoomState State;
float RoomX;
float RoomY;
float PlayerX;
float PlayerY;
int rannum;
//int enemynum = GenerateEnemy();
//int temp = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        State = RoomState.UNDISCOVERED;
        RoomX = transform.position.x;
        RoomY = transform.position.y;
        Enemy1.SetActive(false);
        Enemy2.SetActive(false);
        Enemy3.SetActive(false);

        //print ("Room Created");
        //print ("x: "+transform.position.x.ToString()+" y: "+transform.position.y.ToString());
        //Status();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerY = Triangle.transform.position.y;
        PlayerX = Triangle.transform.position.x;
        if (State != RoomState.COMPLETED)
        {
            UpdateStatus();
        }
    }

    RoomState GetState()
    {
        return State;
    }

    void Status()
    {
        print ("State of ("+gameObject.name.ToString()+"): "+State.ToString());
    }

    void UpdateStatus()
    {
        if((PlayerX >= (RoomX - 3.75) && PlayerY >= (RoomY - 3.75)) && (PlayerX <= (RoomX + 3.75) && PlayerY <= (RoomY + 3.75)))
        {
            gameObject.GetComponent<Battling>().enabled = true;
            Triangle.GetComponent<PlayerMovement>().roombehavior = gameObject;
            int enemynum = GenerateEnemy();
            rannum = enemynum;
            if(enemynum > 0)
            {
                if (enemynum == 1)
                {
                    print ("Enemy one happened");
                    Enemy1.SetActive(true);
                }

                if (enemynum == 2)
                {
                    print ("Enemy two happened");
                    Enemy1.SetActive(true);
                    Enemy2.SetActive(true);
                }

                if (enemynum == 3) //comment
                {
                    print ("Enemy three happened");
                    Enemy1.SetActive(true);
                    Enemy2.SetActive(true);
                    Enemy3.SetActive(true);
                }

                State = RoomState.UNCOMPLETED;
            }

            //add a condtion that checks if enemies are defeated if true complete else false and uncomplete
            //if ((Enemy1 == false) && (Enemy2 == false) && (Enemy3 == false))
            State = RoomState.COMPLETED;
            gameObject.SetActive(true);
            Status();
        }

        if(((PlayerX) >= (RoomX-13.75) && (PlayerY) >= (RoomY-13.75)) && ((PlayerX) <= (RoomX+13.75) && (PlayerY) <= (RoomY+13.75)))
        {
            if(State == RoomState.COMPLETED)
            {
                //print(gameObject.name.ToString()+" was discovered but already completed!");
                Potion();
            }
            else
            {
                State = RoomState.DISCOVERED;
                Status();
            }
        }

        if (State == RoomState.UNDISCOVERED)
        {
            Status();
        }
    }

    int GenerateEnemy()
    {
        int num = Random.Range(1,100);
        if(RoomX == 0 && RoomY ==0)
        {
            print ("Happened here");
            num = 0;
        }
        else if ((num > 0) && (num <= 25))
            num = 0;
        else if ((num > 25) && (num <= 70))
            num = 1;
        else if ((num > 70) && (num <= 90))
            num = 2;
        else if (num > 90)
            num = 3;

        print(num+" Enemies");

        return num;
    }

    void Potion()
    {
        int num = Random.Range(1,100);

        if(num>30)
        {
            return;
        }
        int health_recovered = rannum * 7.5;
        if (Triangle.GetComponent<PlayerStatus>().player_health == Triangle.GetComponent<PlayerStatus>().max_health)
        {
            return;
        }
        else if(Triangle.GetComponent<PlayerStatus>().player_health + health_recovered >= Triangle.GetComponent<PlayerStatus>().max_health)
        {
            Triangle.GetComponent<PlayerStatus>().player_health = Triangle.GetComponent<PlayerStatus>().max_health;
            return;
        }
        else
        Triangle.GetComponent<PlayerStatus>().player_health += health_recovered;
        return;
    }
        
        //Status();

}


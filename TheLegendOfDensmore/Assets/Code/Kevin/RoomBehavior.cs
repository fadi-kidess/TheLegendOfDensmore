using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoomBehavior : MonoBehaviour
{
    public GameObject Triangle;

enum RoomState
    {
        COMPLETED,
        UNCOMPLETED,
        UNDISCOVERED,
        DISCOVERED
    };

RoomState State;
float RoomX;
float RoomY;
float PlayerX;
float PlayerY;
//int temp = 0;

    // Start is called before the first frame update
    void Start()
    {

        State = RoomState.UNDISCOVERED;
        RoomX = transform.position.x;
        RoomY = transform.position.y;

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

    /*RoomState GetStatus()
    {
        return RoomState;
    }*/

    void Status()
    {
        print ("State of ("+gameObject.name.ToString()+"): "+State.ToString());
    }

    void UpdateStatus()
    {
        if((PlayerX >= (RoomX - 3.75) && PlayerY >= (RoomY - 3.75)) && (PlayerX <= (RoomX + 3.75) && PlayerY <= (RoomY + 3.75)))
        {
            //add a condtion that checks if enemies are defeated if true complete else false and uncomplete
            State = RoomState.COMPLETED;
            Status();
        }

        if(((PlayerX) >= (RoomX-13.75) && (PlayerY) >= (RoomY-13.75)) && ((PlayerX) <= (RoomX+13.75) && (PlayerY) <= (RoomY+13.75)))
        {
            if(State == RoomState.COMPLETED)
            {
                print(gameObject.name.ToString()+" was discovered but already completed!");
            }
            else
            {
                //print ("Happened :)");
                State = RoomState.DISCOVERED;
                Status();
            }
        }
        //print (PlayerX);
        //print (PlayerY);
    }
        
        //Status();


}


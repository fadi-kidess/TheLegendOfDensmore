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

    // Start is called before the first frame update
    void Start()
    {

        State = RoomState.UNDISCOVERED;
        RoomX = transform.position.x;
        RoomY = transform.position.y;
        PlayerY = Triangle.transform.position.y;
        PlayerX = Triangle.transform.position.x;
        //print ("Room Created");
        //print ("x: "+transform.position.x.ToString()+" y: "+transform.position.y.ToString());
        //Status();

    }

    // Update is called once per frame
    void Update()
    {
        if (State == RoomState.UNDISCOVERED)
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
                print ("Happened :)");
                State = RoomState.DISCOVERED;
                Status();
            }
        }
    }
        
        //Status();


}


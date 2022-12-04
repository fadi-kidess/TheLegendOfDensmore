using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    bool ismoving = true;
    public float speed;
    private Rigidbody2D playerRigid;
    private Vector3 change;
    public GameObject roombehavior; 
    // Start is called before the first frame update
    void Start()
    {   
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical"); 
        if(change != Vector3.zero && ismoving){
            MoveChar();
        }   
        if(roombehavior.GetComponent<RoomBehavior>().State == RoomBehavior.RoomState.UNCOMPLETED){
            ismoving = false;
        } 
        else if(roombehavior.GetComponent<RoomBehavior>().State == RoomBehavior.RoomState.COMPLETED){
            ismoving = true;
        }
    }

    void MoveChar()
    {
        playerRigid.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

}

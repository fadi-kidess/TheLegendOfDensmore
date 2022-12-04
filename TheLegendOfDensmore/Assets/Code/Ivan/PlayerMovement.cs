using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigid;
    private Vector3 change;
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
        if(change != Vector3.zero){
            MoveChar();
        }

        if(RoomBehavior.RoomState == UNCOMPLETED){
            playerRigid.StopCharacter();
        }
    }

    void MoveChar()
    {
        playerRigid.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

    void StopCharacter(){
        playerRigid.isKinematic = true;
    }
}

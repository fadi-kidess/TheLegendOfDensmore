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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical"); 
        UpdateAnimationForMove();
        if(roombehavior.GetComponent<RoomBehavior>().State == RoomBehavior.RoomState.UNCOMPLETED){
            ismoving = false;
        } 
        else if(roombehavior.GetComponent<RoomBehavior>().State == RoomBehavior.RoomState.COMPLETED){
            ismoving = true;
        }
    }

    void UpdateAnimationForMove(){
        if(change != Vector3.zero && ismoving){
            MoveChar();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y); 
            animator.SetBool("moving", true);
        }   
        else{
            animator.SetBool("moving", false);
        }
    }

    void MoveChar()
    {
        playerRigid.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

}

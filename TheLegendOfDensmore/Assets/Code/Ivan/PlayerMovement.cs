using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public bool ismoving = true;
    public float speed;
    private Rigidbody2D playerRigid;
    private Vector3 change;
    public GameObject roombehavior; 
    private Animator animator;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

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

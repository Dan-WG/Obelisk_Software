using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D Controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public Animator animator;

    bool Can_Move = true;

    bool jump = false;
    bool guard = false;
    bool atk = false;
    bool special = false;
   
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;   //a = -1    d = 1
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown("g"))
        {
            animator.SetBool("Guard", true);
            Can_Move = false;
        }else if (Input.GetKeyUp("g"))
        {
            Can_Move = true;
            animator.SetBool("Guard", false);
        }

        if (Input.GetKeyDown("h"))
        {
            animator.SetBool("Attack", true);
            Can_Move = false;
        }
        else if (Input.GetKeyUp("h"))
        {
            Can_Move = true;
            animator.SetBool("Attack", false);
        }
    }

    void FixedUpdate()
    {
        if (Can_Move)
        {
            Controller.Move(horizontalMove * Time.fixedDeltaTime, jump, guard, atk, special); //move, jump, block, attack 
        }   
        else if (!Can_Move)
        {
            Controller.Move(0.0f, jump, guard, atk, special); //move, jump, block, attack 
        }
          
        jump = false;

    }
}

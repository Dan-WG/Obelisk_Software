using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D Controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public Animator animator;

    bool jump = false;
    bool guard = false;
   
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
        }else if (Input.GetKeyUp("g"))
        {
            animator.SetBool("Guard", false);
        }

    }

    void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, guard, false); //move, crouch, jump, block, attack   
        jump = false;
    }
}

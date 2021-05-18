using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D Controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public Animator animator;

    [SerializeField]
    GameObject specialSprite;

    bool Can_Move = true;

    bool jump = false;
    public bool guard = false;
    bool atk = false;
    bool special = false;

    public Transform AtkPoint;
    public float AtkRange = 1.0f;
    public int Dmg = 15;
    public float AtkRate = 1.0f;
    private float ATkTime = 0f;

    public LayerMask Players;
   
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;   //a = -1    d = 1
        if (Input.GetButtonDown("Jump") && Can_Move)
        {
            jump = true;
        }

        if (Input.GetKey("g"))
        {
            animator.SetBool("Guard", true);
            Can_Move = false;
        }else if (Input.GetKeyUp("g"))
        {
            Can_Move = true;
            animator.SetBool("Guard", false);
        }
        if(Time.time >= ATkTime)
        {
            if (Input.GetKey("h"))
            {
                animator.SetBool("Attack", true);
                Attack();
                Can_Move = false;
                ATkTime = Time.time + 1f / AtkRate;
            }
        }
       
        else if (Input.GetKeyUp("h"))
        {
            Can_Move = true;
            animator.SetBool("Attack", false);
        }

        Special();
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
    void Attack()
    {
        
        Collider2D[] PlayersHit = Physics2D.OverlapCircleAll(AtkPoint.position, AtkRange, Players); //point,radius, layers
        if(guard == true)
        {
            foreach (Collider2D player in PlayersHit)
            {
                player.GetComponent<CharacterStats>().TakeDmg(Dmg);
            }
        }
        else
        {
            foreach (Collider2D player in PlayersHit)
            {
                player.GetComponent<CharacterStats>().TakeDmg(Dmg);
            }
        }
        
    }

    void Special()
    {
        
        if(Time.time >= AtkRate)
        {
            if (Input.GetKeyDown("j"))
            {
                Can_Move = false;
                animator.SetBool("Special", true);
                GameObject shot = Instantiate(specialSprite, AtkPoint.position, Quaternion.Euler(0,0,0));
                Destroy(shot, 1f);
            }
            else 
                if (Input.GetKeyUp("j"))
            {
                Can_Move = true;
                animator.SetBool("Special", false);
            }
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
            return;

        Gizmos.DrawWireSphere(AtkPoint.position, AtkRange);
    }
}

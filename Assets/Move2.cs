using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public P2Controller Controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public Animator animator;

    [SerializeField]
    GameObject specialSprite;


    bool Can_Move = true;

    public bool jump = false;
    public bool guard = false;
    public bool atk = false;
    public bool special = false;

    public Transform AtkPoint;
    public float AtkRange = 1.0f;
    public int Dmg = 15;
    public float AtkRate = 1.0f;
    private float ATkTime = 0f;

    public LayerMask Players;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("P2Horizontal") * runSpeed;   //a = -1    d = 1
        if (Input.GetKey("w") && Can_Move)
        {
            jump = true;
        }

        if (Input.GetKey("c"))
        {
            Debug.Log("si esta bloqueando");
            animator.SetBool("block", true);
            guard = true;
            Can_Move = false;
        }
        else if (Input.GetKeyUp("c"))
        {
            guard = false;
            Can_Move = true;
            animator.SetBool("block", false);
        }
        if (Time.time >= ATkTime)
        {
            if (Input.GetKey("v"))
            {
                animator.SetBool("Attack", true);

                Attack();

                Can_Move = false;
                ATkTime = Time.time + 1f / AtkRate;
            }
        }

        else if (Input.GetKeyUp("v"))
        {
            Can_Move = true;
            animator.SetBool("Attack", false);
        }
        //Special
        if (Time.time >= ATkTime)
        {
            if (Input.GetKey("b"))
            {

                animator.SetBool("Special", true);
                GameObject shot = Instantiate(specialSprite, AtkPoint.position, Quaternion.Euler(0, 0, 0));
                Destroy(shot, 1f);
                Can_Move = false;
                ATkTime = Time.time + 1f / AtkRate;
            }

        }
        else if (Input.GetKeyUp("b"))
        {
            Can_Move = true;
            animator.SetBool("Special", false);
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
    void Attack()
    {

        Collider2D[] PlayersHit = Physics2D.OverlapCircleAll(AtkPoint.position, AtkRange, Players); //point,radius, layers
        if (guard == true)
        {
            foreach (Collider2D player in PlayersHit)
            {
                player.GetComponent<CharacterStats>().TakeDmg(Dmg - 10);
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



    private void OnDrawGizmosSelected()
    {
        if (AtkPoint == null)
            return;

        Gizmos.DrawWireSphere(AtkPoint.position, AtkRange);
    }
}

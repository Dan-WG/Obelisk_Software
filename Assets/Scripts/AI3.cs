using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI3 : MonoBehaviour
{ 
 public float StopDistance;
private float AtkTime;
public float AtkSpeed = 1;
    public float horizontalMove;
    GameObject player;
    Movement atks;
    public bool m_FacingRight = false;  // For determining which way the player is currently facing.


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
{
    if (player != null)
    {
        if (Vector2.Distance(transform.position, player.transform.position) > StopDistance)
        {
                Debug.Log("Yeeet");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }

            //horizontalMove = gameObject.transform.forward *40f;   //a = -1    d = 1
            if (horizontalMove < 0 && m_FacingRight)
            {
                Flip();
            }
            //Move Left
            else if (horizontalMove > 0 && !m_FacingRight)
            {
                Flip();
            }
        }
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int atknum = UnityEngine.Random.Range(0, 3);

            if (atknum == 0)
            {
                atks.jump = true;
            }
            else if (atknum == 1)
            {
                atks.atk = true;
            }
            else if (atknum == 2)
            {
                atks.special = true;
            }
        }
    }

    private void Flip()
    {
        //Flip sprite
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}

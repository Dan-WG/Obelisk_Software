using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed = 3;
    public GameObject bicho;
    bool facingRight = false;

    private CharacterController2D controller;

    // Update is called once per frame
    void Awake()
    {
        bicho = GameObject.FindGameObjectWithTag("Player");
        controller = bicho.GetComponent<CharacterController2D>();

        facingRight = controller.m_FacingRight;

        if (facingRight)
        {
            flip();
        }
    }

    private void Update()
    {
        //sacar el componente d ela scale del bicho y checar si e spositivo o negativo
        if (facingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (!facingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}

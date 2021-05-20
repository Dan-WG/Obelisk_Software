using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public int speed = 3;
   public GameObject bicho;
   Vector3 look;


    // Update is called once per frame
    void Awake()
    {
        if (look.x < 0)
        {
            flip();
        }
    }

    private void Update()
    {
        look = bicho.transform.lossyScale;
        Debug.Log(look.x);
         //sacar el componente d ela scale del bicho y checar si e spositivo o negativo
       if (look.x > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
       else if (look.x < 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }            
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}

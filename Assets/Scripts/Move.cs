using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public int speed = 3;
    public GameObject check;

    // Update is called once per frame
    private void Start()
    {
        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
    }
    void Update()
    {
           transform.Translate(Vector2.left * speed * Time.deltaTime);  
    }

}

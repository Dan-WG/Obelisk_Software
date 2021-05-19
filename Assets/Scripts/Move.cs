using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public int speed = 3;

    // Update is called once per frame
    void FixedUpdate()
    {
           transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

}

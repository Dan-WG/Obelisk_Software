using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI3 : MonoBehaviour
{ 
 public float StopDistance;
private float AtkTime;
public float AtkSpeed = 1;
    GameObject player;
    Movement atks;

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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }
       
        
    }
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(gameObject.tag == "Player"))
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


}

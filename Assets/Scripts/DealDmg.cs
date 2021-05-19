using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public int DmgDealt;
    public LayerMask Players;
    Collider2D[] PlayersHit;
    
 
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayersHit = Physics2D.OverlapBoxAll(gameObject.transform.position, this.transform.lossyScale, 0.0f, Players);

        foreach (Collider2D player in PlayersHit)
            {
            //Debug.Log(player.name);

           
            Destroy(gameObject);
            player.GetComponent<CharacterStats>().TakeDmg(DmgDealt);
         
            }


    }
}

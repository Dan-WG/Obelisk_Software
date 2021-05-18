using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public int DmgDealt;
    public LayerMask Players;
    // Update is called once per frame
    void Awake()
    {
        Collider2D[] PlayersHit = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.lossyScale / 5, 0.0f, Players);

        
        
        foreach (Collider2D player in PlayersHit)
            {
                player.GetComponent<CharacterStats>().TakeDmg(DmgDealt);
            }


    }
}

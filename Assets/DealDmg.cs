using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{

    public LayerMask Players;
    // Update is called once per frame
    void Update()
    {
        Collider2D[] PlayersHit = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale / 2, 0.0f);

        foreach (Collider2D player in PlayersHit)
            {
                player.GetComponent<CharacterStats>().TakeDmg(30);
            }


    }
}

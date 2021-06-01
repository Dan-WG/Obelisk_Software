using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage2 : MonoBehaviour
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
         


            
            player.GetComponent<CharacterStats>().TakeDmg(DmgDealt);
            

        }
        destroy();

    }
    IEnumerator destroy(){
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
        
    }
}

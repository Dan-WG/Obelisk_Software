using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikiStats : MonoBehaviour
{
    public int MaxHp = 100;
    public int currenthp;
    public GameObject Chikis;

    public HealthBar hpbar;

    private void Start() //make max hp current hp on start
    {
        currenthp = MaxHp;
        hpbar.SetHealth(MaxHp);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDmg(10);
        }

        if( currenthp <= 0) //die on 0 hp
        {
            Die();
        }
    }

    void TakeDmg (int dmg) //take dmg accordingly
    {
        currenthp -= dmg;

        hpbar.SetHealth(currenthp);
    }

    void Die() //Destroy gameobject
    {
        Object.Destroy(Chikis, 0.1f);
    }
}

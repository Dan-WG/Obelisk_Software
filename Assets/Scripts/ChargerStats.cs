using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerStats : MonoBehaviour
{
    public int MaxHp = 200;
    public int currenthp;
    public GameObject Charger;

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

        if (currenthp <= 0) //die on 0 hp
        {
            Die();
        }
    }

    void TakeDmg(int dmg) //take dmg accordingly
    {
        currenthp -= dmg;

        hpbar.SetHealth(currenthp);
    }

    void Die() //Destroy gameobject
    {
        Object.Destroy(Charger, 0.1f);
    }
}

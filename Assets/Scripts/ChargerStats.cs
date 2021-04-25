using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerStats : MonoBehaviour
{
    public int MaxHp = 200;
    public int currenthp;

    public HealthBar hpbar;

    private void Start()
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
    }

    void TakeDmg(int dmg)
    {
        currenthp -= dmg;

        hpbar.SetHealth(currenthp);
    }
}

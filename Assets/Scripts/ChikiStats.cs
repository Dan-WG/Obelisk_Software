using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikiStats : MonoBehaviour
{
    public int MaxHp = 100;
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

    void TakeDmg (int dmg)
    {
        currenthp -= dmg;

        hpbar.SetHealth(currenthp);
    }
}

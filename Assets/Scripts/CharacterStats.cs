using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHp = 200;
    public int currenthp;
    public GameObject Character;

    public HealthBar hpbar;

    private void Start() //make max hp current hp on start
    {
        currenthp = MaxHp;
        hpbar.SetHealth(MaxHp);
    }

    private void Update()
    {
        if (currenthp <= 0) //die on 0 hp
        {
            Die();
        }
    }

    public void TakeDmg(int dmg) //take dmg accordingly
    {
        currenthp -= dmg;

        hpbar.SetHealth(currenthp);
    }

    void Die() //Destroy gameobject
    {
        Object.Destroy(Character, 0.1f);
    }
}

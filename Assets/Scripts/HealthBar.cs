using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public void MaxP(int hp)//max hp is equal to hp on start
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
    public void SetHealth(int hp)//stablish slider fill hp to characters hp
    {
        slider.value = hp;
    }
}

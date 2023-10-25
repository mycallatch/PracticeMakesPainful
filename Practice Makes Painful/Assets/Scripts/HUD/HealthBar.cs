using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider;
    
    //Sets health bar to full when called.
    public void SetFullHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    //Sets health bar to new health when player is damaged.
    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

}

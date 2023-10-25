using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public int currentHealth;
    public int currentFullHealth;

    public int Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int FullHealth
    {
        get
        {
            return currentFullHealth;
        }
        set
        {
            currentFullHealth = value;
        }
    }

    //Constructor for PlayerHealth.
    public PlayerHealth(int health, int fullHealth)
    {
        currentHealth = health;
        currentFullHealth = fullHealth;
    }

    //Method to apply damage to a player.
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoImpact : MonoBehaviour
   {
    public HealthBar healthBar;
    [SerializeField] Text WinCount;
    public Rigidbody2D player;

    //Class called once per frame.
    private void Update()
    {
        if (GameManager.gameManager.playerTwoHealth.Health <= 0)
        {
            KO();
        }
    }

    //Used to apply punch damage to the player.
    public void PlayerPunched(int damage)
    {
        GameManager.gameManager.playerTwoHealth.TakeDamage(damage);
        GameManager.gameManager.playerTwoHealth.Health -= damage;
        healthBar.SetHealth(GameManager.gameManager.playerTwoHealth.Health);
        if (GameManager.gameManager.playerOneHealth.Health <= 0)
        {
            KO();
        }
    }

    //Used to apply kick damage to the player.
    public void PlayerKicked(int damage)
    {
        GameManager.gameManager.playerTwoHealth.TakeDamage(damage);
        GameManager.gameManager.playerTwoHealth.Health -= damage;
        healthBar.SetHealth(GameManager.gameManager.playerTwoHealth.Health);
        if (GameManager.gameManager.playerTwoHealth.Health <= 0)
        {
            KO();
        }
    }

    //Method called upon the player's health being reduced to 0.
    public void KO()
    {
        GameManager.gameManager.Reset();
    }
}



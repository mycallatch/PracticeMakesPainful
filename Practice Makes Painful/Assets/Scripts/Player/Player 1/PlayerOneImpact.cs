using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneImpact : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] Text WinCount;
    public Rigidbody2D player;

    //Class called once per frame.
    private void Update()
    {
        if (GameManager.gameManager.playerOneHealth.Health <= 0)
        {
            KO();
        }
    }

    //Used to apply punch damage to player one.
    public void PlayerPunched(int damage)
    {
        GameManager.gameManager.playerOneHealth.TakeDamage(damage);
        GameManager.gameManager.playerOneHealth.Health -= damage;
        healthBar.SetHealth(GameManager.gameManager.playerOneHealth.Health);
        if (GameManager.gameManager.playerOneHealth.Health <= 0)
        {
            KO();
        }
    }

    //Used to apply kick damage to player one.
    public void PlayerKicked(int damage)
    {
        GameManager.gameManager.playerOneHealth.TakeDamage(damage);
        GameManager.gameManager.playerOneHealth.Health -= damage;
        healthBar.SetHealth(GameManager.gameManager.playerOneHealth.Health);
        if (GameManager.gameManager.playerOneHealth.Health <= 0)
        {
            KO();
        }
    }

    //Method called upon player one's health being reduced to 0.
    public void KO()
    {
        GameManager.gameManager.Reset();
    }
}

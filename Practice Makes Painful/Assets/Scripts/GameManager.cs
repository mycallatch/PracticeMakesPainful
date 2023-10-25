using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject winScreenOne;
    public GameObject winScreenTwo;
    public Rigidbody2D player1;
    public Rigidbody2D player2;
    public int winsOne;
    [SerializeField] Text WinCountOne;
    public int winsTwo;
    [SerializeField] Text WinCountTwo;
    public HealthBar healthBarOne;
    private int fullHealthOne;
    public HealthBar healthBarTwo;
    private int fullHealthTwo;
    private float time;
    private float startTime;
    [SerializeField] Text CountDown;
    private bool timeUp;
    public bool resetTrigger;
    public static GameManager gameManager
    {
        get; 
        private set;
    }

    public PlayerHealth playerOneHealth = new PlayerHealth(100, 100);
    public PlayerHealth playerTwoHealth = new PlayerHealth(100, 100);

    // Start is called before the first frame update.
    void Start()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        } else
        {
            gameManager = this;
        }

        winsOne = 0;
        winsTwo = 0;
        fullHealthOne = 100;
        fullHealthTwo = 100;
        startTime = 30f;
        time = 0f;
        time = startTime;
        timeUp = false;
        resetTrigger = false;
    }

    //Class called once per frame.
    private void Update()
    {
        WinCountTwo.text = "Wins: " + winsTwo.ToString();
        WinCountOne.text = "Wins: " + winsOne.ToString();
        Timer();
        Reset();
    }

    //Used to reset the game to it's start state.
    public void Reset()
    {
        if (playerOneHealth.Health <= 0 || playerTwoHealth.Health <= 0)
        {
            HealthZero();
        }
        else if (timeUp)
        {
            TimeUp();
        }
        if (winsOne == 2 || winsTwo == 2)
        {
            Winner();
            GameOver();
        }
    }

    //Method for setting each player's health stat to full.
    public void FullHealth()
    {
        playerTwoHealth.Health = fullHealthTwo;
        playerOneHealth.Health = fullHealthOne;
    }

    //Method for checking when a player's health is reduced to 0, then incrementing their opponent's
    //win counter and refilling health bars.
    private void HealthZero()
    {
        player1.transform.position = new Vector3(-2.37f, -1.97f, 0);
        player2.transform.position = new Vector3(4f, -1.97f, 0);
        if (playerOneHealth.Health <= 0)
        {
            winsTwo++;
            healthBarTwo.SetHealth(fullHealthTwo);
            healthBarOne.SetHealth(fullHealthOne);
        }
        else if (playerTwoHealth.Health <= 0)
        {
            winsOne++;
            healthBarTwo.SetHealth(fullHealthTwo);
            healthBarOne.SetHealth(fullHealthOne);
        }
        FullHealth();
        time = startTime;
    }

    //Method for checking when player has the most health when the timer hits 0, then incrementing
    //their win counter and refilling health bars.

    private void TimeUp()
    {
        player1.transform.position = new Vector3(-2.37f, -1.97f, 0);
        player2.transform.position = new Vector3(4f, -1.97f, 0);
        if (playerOneHealth.Health < playerTwoHealth.Health)
        {
            winsTwo++;
            healthBarTwo.SetHealth(fullHealthTwo);
            healthBarOne.SetHealth(fullHealthOne);
        }
        else if (playerOneHealth.Health > playerTwoHealth.Health)
        {
            winsOne++;
            healthBarTwo.SetHealth(fullHealthTwo);
            healthBarOne.SetHealth(fullHealthOne);
        }
        FullHealth();
        time = startTime;
        timeUp = false;
    }

    //Method for making the timer count down in real time.
    public void Timer()
    {
        if (CountDown != null)
        {
            time -= 1 * Time.deltaTime;
            CountDown.text = time.ToString("0");
        }
        if (time <= 0)
        {
            time = 0;
            timeUp = true;
        }
    }

    //Method for displaying the game over screen.
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    //Method for displaying which player won the set.
    private void Winner()
    {
        if (winsOne >= 2)
        {
            winScreenOne.SetActive(true);
        }
        else if (winsTwo >= 2)
        {
            winScreenTwo.SetActive(true);
        }
    }
}

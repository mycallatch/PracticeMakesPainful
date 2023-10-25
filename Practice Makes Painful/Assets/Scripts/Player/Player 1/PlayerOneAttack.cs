using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneAttack : MonoBehaviour
{

    private bool punch;
    private bool kick;
    public LayerMask oppLayer;
    public Rigidbody2D body;

    public Transform PunchNode;
    public float punchRange;
    public int punchD;
    private float punchP;

    public Transform KickNode;
    public float kickRange;
    public int kickD;
    private float kickP;

    public Animator animator;
    private float punchDelay;
    private float kickDelay;
    private float delay;

    // Start is called before the first frame update.
    void Start()
    {
        punch = false;
        kick = false;
        punchRange = 0.4f;
        kickRange = 0.8f;
        punchD = 2;
        kickD = 1;
        punchP = 5f;
        kickP = 10f;
        punchDelay = 0.8f;
        kickDelay = 1.2f;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame.
    void Update()
    {

        animator.SetBool("punching", punch);
        animator.SetBool("kicking", kick);

        if (Time.time >= delay && Input.GetKeyDown(KeyCode.Q))
        {
            punch = true;
            delay = Time.time + punchDelay;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            punch = false;
        }

        if (Time.time >= delay && Input.GetKeyDown(KeyCode.E))
        {
            kick = true;
            delay = Time.time + kickDelay;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            kick = false;
        }
    }

    // Updates with the Physics Engine once per frame.
    private void FixedUpdate()
    {
        if (punch == true)
        {
            Punch();
        }

        if (kick == true)
        {
            Kick();
        }
    }

    //Method called to apply appropriate damage and knockback to an enemy who is punched.
    private void Punch()
    {
        Collider2D[] punched = Physics2D.OverlapCircleAll(PunchNode.position, punchRange, oppLayer);
        foreach (Collider2D opp in punched)
        {
            opp.GetComponent<PlayerTwoImpact>().PlayerPunched(punchD);
            punchKnockback(opp);
            break;
        }
    }

    //Method called to apply appropriate damage and knockback to an enemy who is kicked.
    void Kick()
    {
        Collider2D[] kicked = Physics2D.OverlapCircleAll(KickNode.position, kickRange, oppLayer);
        foreach (Collider2D opp in kicked)
        {
            opp.GetComponent<PlayerTwoImpact>().PlayerKicked(kickD);
            kickKnockback(opp);
            break;
        }
    }

    //Method used to apply a force on the enemy if they are punched by the player.
    public void punchKnockback(Collider2D player)
    {
        Vector2 trajectory = (player.transform.position - transform.position).normalized;
        body.AddForce(trajectory * punchP, ForceMode2D.Impulse);
    }

    //Method used to apply a force on the enemy if they are punched by the player.
    public void kickKnockback(Collider2D player)
    {
        Vector2 trajectory = (player.transform.position - transform.position).normalized;
        body.AddForce(trajectory * kickP, ForceMode2D.Impulse);
    }
}

using System.Collections;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private float moveSpeed;
    private float jumpForce;
    private bool isJump;
    private float moveHoz;
    private float moveVert;

    private bool dashAvail;
    private bool isDash;
    private float dashSpeed;
    private float dashTime;
    public float speedBase;
    public float dashRest;
    public bool dash;

    public bool lookRight;
    public Animator animator;

    // Start is called before the first frame update.
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        moveSpeed = 1.5f;
        jumpForce = 35f;
        isJump = false;
        dashAvail = true;
        isDash = false;
        dashSpeed = 15f;
        dashTime = 0.2f;
        speedBase = 1.5f;
        dashRest = 0.2f;
    }

    // Update is called once per frame.
    void Update()
    {

        animator.SetFloat("horizontal", Mathf.Abs(moveHoz));
        animator.SetFloat("vertical", Mathf.Abs(moveVert));
        animator.SetBool("dashing", dash);

        if (isDash)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveHoz = 1;
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            moveHoz = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveHoz = -1;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            moveHoz = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveVert = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            moveVert = 0;
        }

        dash = Input.GetKeyDown(KeyCode.LeftShift);
    }

    // Updates with the Physics Engine once per frame.
    private void FixedUpdate()
    {
        if (isDash) {
            return;
        }

        if(moveHoz > 0.1f || moveHoz < -0.1f)
        {
            player.AddForce(new Vector2(moveHoz * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (moveHoz < 0 && !lookRight)
        {
            Invert();
        } 
        if (moveHoz > 0 && lookRight) {
            Invert();
        }

        if (!isJump && moveVert > 0.1f)
        {
            player.AddForce(new Vector2(0f, moveVert * jumpForce), ForceMode2D.Impulse);
        }

        if(dash && dashAvail)
        {
            StartCoroutine(Dash());
        }
    }

    //Checks if game object is in contact with the ground, if so it is not jumping.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isJump = false;
        }
    }
    
    //Check if game object is in contact with the ground, if not it is jumping.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isJump = true;
        }
    }

    //Method for dashing in game.
    private IEnumerator Dash()
    {
        dashAvail = false;
        isDash = true;
        player.AddForce(new Vector2(player.transform.localScale.x * dashSpeed, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(dashTime);
        isDash = false;
        yield return new WaitForSeconds(dashRest);
        dashAvail = true;
    }

    //Method used to flip the direction the player is facing.
    void Invert()
    {
        Vector2 startDirection = player.transform.localScale;
        startDirection.x *= -1f;
        player.transform.localScale = startDirection;
        lookRight = !lookRight;
    }
}

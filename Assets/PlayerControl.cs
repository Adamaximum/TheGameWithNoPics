using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 0.2f;
    float horizontalInput;

    [Range(1,10)]
    public float jumpVelocity = 2;

    public bool jumpCheck = true;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Rigidbody2D playerRB;

    public bool jumpInputType;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();

        if (jumpInputType == false)
        {
            JumpInputV1();
        }
        else if (jumpInputType == true)
        {
            JumpInputV2();
        }
        
    }

    void MovementInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -playerSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = playerSpeed;
        }
        else
        {
            horizontalInput = 0;
        }

        transform.position += new Vector3(horizontalInput, 0, 0);
    }

    void JumpInputV1() //Using GetKeyDown
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jumpCheck == true)
        {
            playerRB.velocity = Vector2.up * jumpVelocity;
        }

        //Control-Pressured Jumping
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y > 0 && (!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.UpArrow)))
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void JumpInputV2() //Using GetButtonDown
    {
        if (Input.GetButtonDown("Jump") && jumpCheck == true)
        {
            playerRB.velocity = Vector2.up * jumpVelocity;
        }

        //Control-Pressured Jumping
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpCheck = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            jumpCheck = false;
        }
    }
}

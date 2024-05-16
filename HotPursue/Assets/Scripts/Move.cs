using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float xDir, yDir;
    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxis("Horizontal");
        yDir = Input.GetAxis("Vertical");

        if (xDir == 0 && yDir == 0)
        {
            playerState.ChangeState(State.Idle);
        } else
        {
            if (xDir < 0)
            {
                playerState.ChangeState(State.RunL);
            } else
            {
                playerState.ChangeState(State.RunR);
            }
        }

        rb.velocity = new Vector2(xDir, yDir) * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAva : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 50;
    public Transform rayTranform;

    Animator animator;
    Rigidbody2D rb;

    bool isFloor = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal");
        Vector2 direction = transform.right;
        rb.velocity = new Vector2(direction.x* hor*speed, rb.velocity.y);

        animator.SetFloat("hor", Mathf.Abs(hor));

        if (hor > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (hor < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {

        }

        if (Input.GetKeyDown(KeyCode.Space) && isFloor)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        // ==============================================
        Debug.DrawRay(rayTranform.position, -rayTranform.up * 0.5f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(rayTranform.position, -rayTranform.up, 0.5f);

        if (hit)
        {
            isFloor = true;
        }
        else
        {
            isFloor = false;
        }
    }
}
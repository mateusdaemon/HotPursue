using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekHard : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;

    Vector2 targetPosition;
    Vector2 direction;        // direção com magnitude 1
    Vector2 velocity;         // direcao com speed
    Vector2 desiredVelocity;

    public float speed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        targetPosition = target.transform.position;

        // ==================================================================
        direction = ((Vector3)targetPosition - transform.position).normalized;

        desiredVelocity = direction * speed;

        velocity = desiredVelocity;

        Rotate();
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;

    Vector2 targetPosition;
    Vector2 direction;
    Vector2 velocity;

    public float speed = 5;

    Vector2 desired_velocity;
    Vector2 steering_velocity;
    public float mass = 10;

    public bool DetectProximity = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (target == null)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
            targetPosition = target.transform.position;



        if (Vector2.Distance(targetPosition, transform.position) < 4 || !DetectProximity)
        {
            // Seek Direction
            direction = ((Vector3)targetPosition - transform.position).normalized;
            desired_velocity = direction * speed;

            desired_velocity = -desired_velocity; // com Flee Direction

            steering_velocity = desired_velocity - velocity;
            steering_velocity = steering_velocity / mass;

            velocity += steering_velocity;

            Rotate();
        }
        else
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, 0.005f);
        }
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

     private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}

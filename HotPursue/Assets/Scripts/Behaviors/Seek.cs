using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;

    Vector2 targetPosition;

    Vector2 direction;
    Vector2 velocity;

    public float speed = 5;

    // =========================
    Vector2 desired_velocity;
    Vector2 steering_velocity;
    public float mass = 10;

    private EnemyState enemyState;
    private bool goToPlayer = false;
    public float checkRadios;
    public LayerMask whatIsPlayer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        enemyState = GetComponent<EnemyState>();
    }

    private void Update()
    {
        if (!goToPlayer)
        {
            Collider2D playerRef = Physics2D.OverlapCircle(transform.position, checkRadios, whatIsPlayer);
            if (playerRef)
            {
                goToPlayer = true;
            }
        } else
        {
            targetPosition = target.transform.position;

            if (targetPosition.x > transform.position.x)
            {
                enemyState.ChangeState(State.RunR);
            }
            else
            {
                enemyState.ChangeState(State.RunL);
            }

            // ========================================================
            direction = ((Vector3)targetPosition - transform.position).normalized;
            desired_velocity = direction * speed;

            steering_velocity = desired_velocity - velocity;
            steering_velocity = steering_velocity / mass;

            velocity += steering_velocity;
        }
      
        //Rotate();
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
        Collider2D playerRef = Physics2D.OverlapCircle(transform.position, checkRadios, whatIsPlayer);

        if (playerRef)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(transform.position, checkRadios);
    }
}

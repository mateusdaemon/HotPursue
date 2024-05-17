using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour {
    Rigidbody2D rb;
    Rigidbody2D targetRb;

    private GameObject target;
    private EnemyState enemyState;
	Vector2 targetPos;

    Vector2 direction;
    Vector2 velocity = new Vector2(1,0);
	
    Vector2 desired_velocity;
	Vector2 steering_velocity;

	public float speed = 5;
	public float mass = 20;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        targetRb = target.GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyState>();
    }

    private void Update()
	{
        targetPos = GetTargetFuturePosition();

        if (target.transform.position.x > transform.position.x)
        {
            enemyState.ChangeState(State.RunR);
        } else
        {
            enemyState.ChangeState(State.RunL);
        }

        direction = (targetPos - (Vector2)transform.position).normalized;
        desired_velocity = direction * speed;

		steering_velocity = desired_velocity - velocity;
		steering_velocity = steering_velocity / mass;

		velocity += steering_velocity;
	}

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    Vector2 GetTargetFuturePosition()
    {
        if (targetRb.velocity.magnitude > 0.5f)
        {
            float distance = Vector2.Distance(target.transform.position, transform.position);
            float T = distance / targetRb.velocity.magnitude;

            return (Vector2)target.transform.position + (targetRb.velocity * T);
        }
        else
            return target.transform.position;
    }

    private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(targetPos, 0.5f);
	}


}

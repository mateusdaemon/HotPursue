using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

	Rigidbody2D rb;

	Vector2 targetPosition;

	Vector2 position;
	Vector2 velocity = new Vector2(1,0);

	Vector2 desired_velocity;
	Vector2 steering_velocity;

	public float speed = 5;
	public float mass = 20;

	// ===========================
	Vector2 displacement;
	bool isColliding = false;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		wander();
	}

	private void Update()
	{
		//ShowDebug();

		position = transform.position;

		desired_velocity = (targetPosition - position).normalized * speed;

		steering_velocity = desired_velocity - velocity;
		steering_velocity = steering_velocity / mass;

		velocity += steering_velocity;

		rb.velocity = velocity;

		Rotate();
		
		// chegou no target
		if (Vector2.Distance(targetPosition, transform.position)  < 0.5f)
		{
			wander();
		}
	}

	private void FixedUpdate()
	{
		// encostou em algo
		RaycastHit2D hit = Physics2D.Raycast(position, transform.right, 2);
		if (hit.collider && !isColliding) 
		{
			isColliding = true;
			targetPosition = -targetPosition;
		}
		else if (!hit.collider)
		{
			isColliding = false;
		}

		Debug.DrawRay(position, transform.right * 2, Color.cyan);
	}

	void Rotate()
	{
		float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0, 0, angle);
	}

	void wander()  {
		isColliding = false;

		float wanderAngle = transform.eulerAngles.z + Random.Range(-120, 120);
		displacement = GetVectorFromAngle(wanderAngle);

		targetPosition = position + displacement * 10;
		
		CancelInvoke();
		Invoke("wander", Random.Range(2,8));
	}

	Vector2 GetVectorFromAngle(float value) {
		value = value * Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(value), Mathf.Sin(value));
	}

	// =========================================================
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(targetPosition, 1);
	}

	void ShowDebug()
	{
		// diplacement
		Debug.DrawLine(position, position + displacement, Color.red);
		// velocity
		Debug.DrawLine(position, position + velocity, Color.green);
	}
}

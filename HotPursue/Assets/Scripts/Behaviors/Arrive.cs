using UnityEngine;

public class Arrive : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject target;

	Vector2 targetPos;
	Vector2 position;

	Vector2 direction;
	Vector2 velocity;

	Vector2 desired_velocity;
	Vector2 steering_velocity;

	public float speed = 5;
	public float mass = 20;

	// area de frenagem
	public float slowRadius = 3;
	public float stopRadius = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
	{
		position = transform.position;
		targetPos = target.transform.position;

		float distance = Vector2.Distance(targetPos, position);

		if (distance < stopRadius)
		{
			steering_velocity = Vector2.zero;
			velocity = Vector2.zero;
		}
		else if (distance > slowRadius)
		{
			direction = (targetPos - position).normalized;
			desired_velocity = direction * speed;

			steering_velocity = desired_velocity - velocity;
			steering_velocity = steering_velocity / mass;
		}
		else {
			direction = (targetPos - position).normalized;
			desired_velocity = direction * speed * (distance / slowRadius);
			
			steering_velocity = desired_velocity - velocity;
		}

		velocity += steering_velocity;

		if (velocity != Vector2.zero)
			Rotate();
	}

	private void FixedUpdate()
	{
		rb.velocity = velocity;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(targetPos, slowRadius);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(targetPos, stopRadius);
	}

    void Rotate()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}

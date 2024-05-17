﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] arrPaths;
    int index = 0;

    Vector2 targetPosition;

    Vector3 direction;
    Vector3 velocity;

    public float speed = 5;

    // =========================
    Vector3 desired_velocity;
    Vector3 steering_velocity;
    public float mass = 10;

    private void Start()
    {
        InvokeRepeating("ChangePoint", 0, 3);
    }

    private void Update()
    {
        //targetPosition = target.transform.position;

        direction = ((Vector3)targetPosition - transform.position).normalized;
        desired_velocity = direction * speed * Time.deltaTime;

        steering_velocity = desired_velocity - velocity;
        steering_velocity = steering_velocity / mass;

        velocity = velocity + steering_velocity;

        if (Vector2.Distance(targetPosition, transform.position) > 0.5f)
            transform.position += velocity;

        Rotate();
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void ChangePoint()
    {
        index++;

        if (index >= arrPaths.Length)
        {
            index = 0;
        }

        targetPosition = arrPaths[index].transform.position;
    }

}

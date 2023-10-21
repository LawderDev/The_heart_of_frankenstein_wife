using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private void Start()
    {
        // Find the target GameObject by name or tag
        target = GameObject.Find("TargetObject").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector2 direction = (target.position - transform.position).normalized;

            // Move towards the target
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}

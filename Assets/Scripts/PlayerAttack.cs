using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectiles;
    
    private float cooldownAttackTimer = Mathf.Infinity;
    private float cooldownDashTimer = Mathf.Infinity;

    private Rigidbody2D rb;

    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0f;
    [SerializeField] private float dashingDuration = 10f;
    [SerializeField] private float dashCooldown = 1f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownAttackTimer > attackCooldown)
            Attack();

        if (Input.GetMouseButtonDown(1) && cooldownDashTimer > dashCooldown)
           Skill();

        if(isDashing){
            if(transform.localScale.x > 0)
                rb.velocity = new Vector2(dashingPower, rb.velocity.y);
            else
                rb.velocity = new Vector2(-dashingPower, rb.velocity.y);

            dashingTime += Time.deltaTime;
            if(dashingTime > dashingDuration){
                isDashing = false;
                dashingTime = 0;
            }
        }
        cooldownAttackTimer += Time.deltaTime;
        cooldownDashTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownAttackTimer = 0;

        projectiles[FindProjectile()].transform.position = projectilePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Skill()
    {
        isDashing = true;
        cooldownDashTimer = 0;
    }
}

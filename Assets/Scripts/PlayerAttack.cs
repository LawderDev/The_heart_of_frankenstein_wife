using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectiles;

    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

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
}

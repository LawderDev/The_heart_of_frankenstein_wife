using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        print("PLAYER : DAMAGED");
        currentHealth -= damage;
        print(currentHealth);

        if (currentHealth <= 0)
        {
            // Implement death or any other logic when health reaches 0
            Die();
        }
    }

    private void Die()
    {
        // Implement what should happen when the entity dies
        // For example, you can destroy the GameObject
        print("GAME OVER : The HPlayer died");
        Destroy(gameObject);
    }
}

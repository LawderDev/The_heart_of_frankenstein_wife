using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private HealthBarHeartUI healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        print("HEART : DAMAGED");
        SetHealth(-damage);
        print(currentHealth);

        if (currentHealth <= 0)
        {
            // Implement death or any other logic when health reaches 0
            Die();
        }
    }

    public void SetHealth(int healthChange){
        currentHealth += healthChange;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        // Implement what should happen when the entity dies
        // For example, you can destroy the GameObject
        print("GAME OVER : The Heart died");
        Destroy(gameObject);
    }
}

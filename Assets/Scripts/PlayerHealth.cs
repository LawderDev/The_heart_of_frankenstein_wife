using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField]
    private HealthBarPlayerUI healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        print("PLAYER : DAMAGED");
        SetHealth(-damage);
        print(currentHealth);        
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
        print("GAME OVER : The HPlayer died");
        Destroy(gameObject);
    }
}

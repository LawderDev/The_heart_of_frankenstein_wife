using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField]
    private HealthBarPlayerUI healthBar;

    private bool invincibility = false;
    private float cooldownInvincibility = Mathf.Infinity;
    private float invincibilityTime = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    public void setInvinsibility(bool value){
        invincibility = value;
        if(value){
            cooldownInvincibility = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if(!invincibility){
            print("PLAYER : DAMAGED");
            SetHealth(-damage);
            print(currentHealth);

            if (currentHealth <= 0)
            {
                // Implement death or any other logic when health reaches 0
                Die();
            }  
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

    public int GetHealth(){
       return currentHealth;
    }

    private void Update()
    {  
        cooldownInvincibility += Time.deltaTime;
        if(cooldownInvincibility > invincibilityTime)
            setInvinsibility(false);
    }

    private void Die()
    {
        // Implement what should happen when the entity dies
        // For example, you can destroy the GameObject
        print("GAME OVER : The HPlayer died");
        Destroy(gameObject);
    }
}

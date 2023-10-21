using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySimple : MonoBehaviour
{

    public int maxHealth = 100;
    public float health;
    public int damage = 5;
    public HeartHealth heart;
    public PlayerHealth player;
    public float attackCooldownHeart;
    public float attackCooldownPlayer;

    float _lastAttackTimeHeart;
    float _lastAttackTimePlayer;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        heart = GameObject.Find("Heart").GetComponent<HeartHealth>();
        player = GameObject.Find("Grid/Player").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - _lastAttackTimePlayer < attackCooldownPlayer) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            print("ATTACKED : PLAYER");
            player.TakeDamage(damage);
            _lastAttackTimePlayer = Time.time;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
         if (Time.time - _lastAttackTimeHeart < attackCooldownHeart) return;
         
         if (collision.gameObject.CompareTag("TargetObject"))
        {
            print("ATTACKED : HEART");
            heart.TakeDamage(damage);
            _lastAttackTimeHeart = Time.time;
        }
    }

    public void TakeDamage(float damage){
        health -= damage;
        print(health);
        if (health <= 0){
            Die();
        }
    }

    private void Die(){
         Destroy(gameObject);
    }
}

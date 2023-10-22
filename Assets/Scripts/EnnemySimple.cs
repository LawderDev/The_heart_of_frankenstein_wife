using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySimple : MonoBehaviour
{

    public int maxHealth = 100;
    public float health;
    public int damage = 5;
    public int damageBarricade = 1;
    public Transform ennemyPosition;
    public HeartHealth heart;
    public PlayerHealth player;
    public BarricadeHealth bLD,bLU,bRD,bRU;
    public PlayerAttack playerAttack;
    public float attackCooldownHeart;
    public float attackCooldownPlayer;
    public float attackCooldownBarricade;

    float _lastAttackTimeHeart;
    float _lastAttackTimePlayer;
    float _lastAttackTimeBarricade;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
        heart = GameObject.Find("Heart").GetComponent<HeartHealth>();
        player = GameObject.Find("Grid/Player").GetComponent<PlayerHealth>();
        playerAttack = GameObject.Find("Grid/Player").GetComponent<PlayerAttack>();

        bLD = GameObject.Find("Grid/BarricadeLeftDown").GetComponent<BarricadeHealth>();
        bLU = GameObject.Find("Grid/BarricadeLeftUp").GetComponent<BarricadeHealth>();
        bRU = GameObject.Find("Grid/BarricadeRightUp").GetComponent<BarricadeHealth>();
        bRD = GameObject.Find("Grid/BarricadeRightDown").GetComponent<BarricadeHealth>();
    }

    void Update(){
        if (ennemyPosition.position.y < -20){
            Die();
        }
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            print("SKILL DAMAGE");
            TakeDamage(playerAttack.getDashingDamage());
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        
         
         if (collision.gameObject.CompareTag("TargetObject"))
        {
            if (Time.time - _lastAttackTimeHeart < attackCooldownHeart) return;
            print("ATTACKED : HEART");
            heart.TakeDamage(damage);
            _lastAttackTimeHeart = Time.time;
        }

        if (collision.gameObject.CompareTag("Barricade"))
        {
            if (Time.time - _lastAttackTimeBarricade < attackCooldownBarricade) return;
            BarricadeHealth bh = collision.gameObject.GetComponent<BarricadeHealth>();
            if (bh != null)
            {
                // Compare the BarricadeHealth component to specific instances
                if (bh.name == "BarricadeLeftDown")
                {
                    print("ATTACKED : BLD");
                    bLD.TakeDamage(damageBarricade);
                }
                else if (bh.name == "BarricadeLeftUp")
                {
                    bLU.TakeDamage(damageBarricade);
                }
                else if (bh.name == "BarricadeRightDown")
                {
                    bRD.TakeDamage(damageBarricade);
                }
                else if (bh.name == "BarricadeRightUp")
                {
                    bRU.TakeDamage(damageBarricade);
                }
                _lastAttackTimeBarricade = Time.time;
            }
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

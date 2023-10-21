using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySimple : MonoBehaviour
{

    public int maxHealth = 100;
    public int health;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    void TakeDamage(int playerDamage){
        health -= damage;
        if (health <= 0){
            Destroy(GameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.GameObject.tag == "Player"){
            player.TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

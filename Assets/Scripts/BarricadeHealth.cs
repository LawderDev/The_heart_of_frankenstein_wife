using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] public SpriteRenderer renderer;
    [SerializeField] public Sprite sp1, sp2, sp3, sp4;
    [SerializeField] private BoxCollider2D box;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sp1;
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(box.enabled == false && currentHealth > 0){
            box.enabled = true;
            renderer.sprite = sp3;

        }
    }

    public void TakeDamage(int damage)
    {
        SetHealth(-damage);
        print(currentHealth);
    }

    public void SetHealth(int healthChange){
        if (currentHealth > 0 || currentHealth < maxHealth){
            currentHealth += healthChange;
        }
        if (currentHealth >= 75)
        {
            renderer.sprite = sp1;
        }
        else if(currentHealth >= 50){
            renderer.sprite = sp2;
        }
        else if (currentHealth >= 25){
            renderer.sprite = sp3;

        }else if(currentHealth <= 0){
            renderer.sprite = sp4;
            box.enabled = false;
        }
    }
}

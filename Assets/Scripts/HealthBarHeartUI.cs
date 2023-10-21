using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHeartUI : MonoBehaviour
{
    public int Health;
    public int MaxHealth = 100;
    public Slider slider;

    public void SetMaxHealth(int maxHealth) {
        MaxHealth = maxHealth;
        slider = GetComponent<Slider>();
        slider.maxValue = (float)MaxHealth;
        slider.value = (float)Health;
    }

    public void SetHealth(int health) {
        Health = health;
        slider.value = Health;
    }
}

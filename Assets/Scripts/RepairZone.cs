using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairZone : MonoBehaviour
{
    public int healingAmount = 5; // Adjust the amount of healing as needed.
    public BarricadeHealth barricade;
    public PlayerMove player;
    public float repairCooldown; 
    private float _lastRepairTime;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time - _lastRepairTime < repairCooldown) return;

        if (other.CompareTag("Player"))
        {
            if ( Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) ){
                print("HEALED : Barricade");
                barricade.SetHealth(healingAmount);
                _lastRepairTime = Time.time;
            }
        }
    }
}

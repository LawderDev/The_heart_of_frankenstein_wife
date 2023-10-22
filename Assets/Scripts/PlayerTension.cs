using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTension : MonoBehaviour
{
    private float tension = 10;
    [SerializeField] float tensionIncrementValue = 1f;
    private GameObject[] objectsWithTag;
    private int countEnnemiesOnField;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("IncreaseTension", 1.0f, 1.0f); // Appel de la fonction toutes les 1 seconde après 1 seconde initiale
    }

    private void tensionEnnemies(){
        objectsWithTag = GameObject.FindGameObjectsWithTag("Ennemy");
        countEnnemiesOnField = objectsWithTag.Length;

        float incrementFactor = 0;

        if (countEnnemiesOnField >= 10 && countEnnemiesOnField < 20)
        {
            incrementFactor = 0.01f;
        }
        else if (countEnnemiesOnField >= 20 && countEnnemiesOnField < 30)
        {
            incrementFactor = 0.05f;
        }
        else if (countEnnemiesOnField >= 30 && countEnnemiesOnField < 40)
        {
            incrementFactor = 0.15f;
        }
        else if (countEnnemiesOnField >= 40 && countEnnemiesOnField < 50)
        {
            incrementFactor = 0.25f;
        }
        else if (countEnnemiesOnField >= 50)
        {
            incrementFactor = 0.35f;
        }

        if (tension + tensionIncrementValue + (tensionIncrementValue * incrementFactor) > 100)
        {
            tension = 100;
        }
        else
        {
            tension += tensionIncrementValue + (tensionIncrementValue * incrementFactor);
        }
    }

    public void decrementTension(float value){
        if(tension - value > 10){
            tension -= value;
        }else{
            tension = 10;
        }
    }

    public float getTension(){
        return tension;
    }

    private void IncreaseTension()
    {
        tensionEnnemies();
        Debug.Log("TENSION: " + tension);
    }

}

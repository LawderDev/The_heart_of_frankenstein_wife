using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTension : MonoBehaviour
{
    private float tension = 10;
    [SerializeField] float tensionIncrementValue = 1f;
    [SerializeField] private TensionBarUI tensionBar;
    private GameObject[] objectsWithTag;
    private GameObject[] barricadeWithTag;
    private int countEnnemiesOnField;
    private int countBarricadeOnField;
    private int downBarri = 0;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("IncreaseTension", 1.0f, 1.0f); // Appel de la fonction toutes les 1 seconde après 1 seconde initiale
        tensionBar.setTension(tension);
    }

    private void tensionEnnemies(){
        objectsWithTag = GameObject.FindGameObjectsWithTag("Ennemy");
        countEnnemiesOnField = objectsWithTag.Length;

        barricadeWithTag = GameObject.FindGameObjectsWithTag("Barricade");
        countBarricadeOnField = objectsWithTag.Length;

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

        downBarri = 0;
        foreach(GameObject b in barricadeWithTag){
            if (b.GetComponent<BoxCollider2D>().enabled == false){
                downBarri += 1;
            }
        }
        if (downBarri > 0){
            Debug.Log("DownBarri: " + downBarri);
            incrementFactor = incrementFactor * downBarri;
            Debug.Log("IncrementFactor: " + incrementFactor);
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
        tensionBar.setTension(tension);
    }

    public float getTension(){
        return tension;
    }

    private void IncreaseTension()
    {
        tensionEnnemies();
        tensionBar.setTension(tension);
        Debug.Log("TENSION: " + tension);
    }

}

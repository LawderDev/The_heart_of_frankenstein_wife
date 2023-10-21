using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public GameObject entityPrefab;  // Assign your prefab in the Unity Inspector
    public int numberOfEntities = 1; // Number of entities to spawn
    public float spawnInterval = 1.0f; // Time between spawns (if you want to spawn them with a delay)
    public int maxEntitiesOnField = 10;
    private GameObject[] objectsWithTag;
    private int countEnnemiesOnField;
    private void Start()
    {
        // Call the SpawnEntities method after a specified delay (optional)
        InvokeRepeating("SpawnEntities", 1, spawnInterval);
    }

    private void Update(){
        objectsWithTag = GameObject.FindGameObjectsWithTag("Ennemy");
        countEnnemiesOnField = objectsWithTag.Length;
    }

    void SpawnEntities()
    {
        for (int i = 0; i < numberOfEntities; i++)
        {
            if (countEnnemiesOnField < maxEntitiesOnField){
                Vector3 spawnPosition = transform.position; // Adjust position as needed
            // Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360), 0); // Adjust rotation as needed

                Instantiate(entityPrefab, spawnPosition, Quaternion.identity);//, spawnRotation);
            }
        }
    }
}

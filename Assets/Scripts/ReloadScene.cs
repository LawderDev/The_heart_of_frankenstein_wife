using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public KeyCode reloadKey = KeyCode.N; // Set the key you want to use for reloading.

    void Update()
    {
        if (Input.GetKey(reloadKey))
        {
            ReloadCurrentScene();
        }
    }

    void ReloadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Debug.Log("RELOADED LEVEL");
    }
}

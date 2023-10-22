using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bpm : MonoBehaviour
{

    public AudioSource audioSource; // Assurez-vous de définir l'AudioSource dans l'éditeur Unity
    public PlayerTension player;
    public HeartHealth heartHealth;
    public AudioClip newAudioClip;
    // Mettez à jour la vitesse du son en fonction de la variable spécifiée
    void Update()
    {
        // Assurez-vous d'ajuster cette variable en fonction de votre logique de jeu
        if(heartHealth.getHealth() <= 0){
            audioSource.loop = false;
            audioSource.pitch = 1f;
            audioSource.clip = newAudioClip;
            audioSource.volume = 0.01f;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            return;
        }
        
        if(player.getTension() > 60f ){
            audioSource.pitch = 0.75f + 0.45f; // 120
        }else if(player.getTension() > 40f ){
            audioSource.pitch = 0.75f + 0.25f; // 100
        }else if(player.getTension() > 20f ) {
            audioSource.pitch = 0.75f + 0.05f; //80
        }else if(player.getTension() > 15f ){
            audioSource.pitch = 0.75f;
        }

        
        // Augmenter la vitesse du son en fonction de la variable
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumps = 2; // Nombre maximal de sauts

    private float  initialColliderSizeY = 0;
    private Vector2 initialColliderOffset;
    private BoxCollider2D playerCollider;
    private Rigidbody2D body;
    private int jumpCount = 0;
    private bool ctrlPressed = false;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        initialColliderSizeY = playerCollider.size.y;
        initialColliderOffset = playerCollider.offset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount++;
        }
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                
                 playerCollider.size = new Vector2(playerCollider.size.x, playerCollider.size.y - initialColliderSizeY / 2f);
                 playerCollider.offset = new Vector2(playerCollider.offset.x, playerCollider.offset.y - initialColliderSizeY / 4f);
                 ctrlPressed = true;
            }
        } 
        else // Si la touche est relâchée, rétablir la taille initiale
        {
            if (ctrlPressed) // Vérifier si la touche vient d'être relâchée
            {
                playerCollider.size = new Vector2(playerCollider.size.x, initialColliderSizeY);
                playerCollider.offset = initialColliderOffset;
                ctrlPressed = false; // Mettre à jour l'état de la touche
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; // Réinitialiser le compteur de sauts lorsque le joueur touche le sol
        }
    }
}

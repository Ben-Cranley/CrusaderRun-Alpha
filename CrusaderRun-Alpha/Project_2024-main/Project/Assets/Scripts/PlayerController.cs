using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed at which the player moves
    private float speed = 30.0f;
    // player's input for horizontal movement (left/right)
    private float horizontalInput;
    // Limits player's movement on the X-axis
    private float xRangeLeft = -8.0f;
    private float xRangeRight = 28.0f;
    private SpawnManager spawnManager;
    private AudioSource crashSound;
    public AudioClip  playerCrash;

    void Start(){
        crashSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        // Prevents the player from moving beyond the defined X-axis limits
        if (transform.position.x < xRangeLeft)
        {
            transform.position = new Vector3(xRangeLeft, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRangeRight)
        {
            transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
        }

        // Get horizontal input from the player 
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player left and right based on horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    // Called when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        
        // This checks if the player collided with an object tagged as "Car"
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Game Over!");
            crashSound.PlayOneShot(playerCrash, 1.0f);
            
            
            //pauses game  
            Time.timeScale = 0;     
        }
    }
}

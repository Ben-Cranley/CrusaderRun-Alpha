using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Define the boundary limits
    // The Z position beyond which the object will be destroyed
    private float topBound = 1000;
    // The Z position below which the object will be destroyed    
    private float lowerBound = -5;   

    // call script// beta 
    private SpawnManager spawnManager;

    void Start()
    {
        
    }

    void Update()
    {
        
        // If the object moves past the top boundary, it will be destroyed
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            
        }
        // If the object moves past the lower boundary, it will also be destroyed
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            

        }
    }
}


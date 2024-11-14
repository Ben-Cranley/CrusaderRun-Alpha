using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    //  different car prefabs that can be spawned
    public GameObject[] carPrefabs;
    // Delay before the first car is spawned
    private float startDelay = 0.25f;
    // Interval between each car spawn
    private float spawnInterval = 1.5f;
    //score
    public TextMeshProUGUI scoreText;
    private int score;
    //game over 
    public TextMeshProUGUI gameOver;

    
    void Start()
    {
        // Repeatedly invoke the SpawnRandomCar method with the specified start delay and interval
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval);
        // to start score at 0 
        score = 0;
        UpdateScore(0);
       
    }

    // Method to spawn a random car at a random position
void SpawnRandomCar()
{
    // These positions represent different lanes on the X-axis where the cars can spawn
    float[] spawnPositionsX = new float[] { -7.25f, -5.0f, -3.0f, 2.5f, 6.5f, 7.5f, 15.5f, 15.0f, 17.0f, 22.5f, 25.5f, 27.0f };

    // Debug logs to check the array length and the random index for spawnPositionsX
    Debug.Log("spawnPositionsX length: " + spawnPositionsX.Length);
    int randomIndexX = Random.Range(0, spawnPositionsX.Length);
    Debug.Log("Random index for X position: " + randomIndexX);

    // Randomly select one of the X positions from the spawnPositionsX array
    float spawnPosX = spawnPositionsX[randomIndexX];

    // This random range determines how far along the Z-axis the car will spawn
    float spawnPosZ = Random.Range(10f, 150.0f);

    // Create the final spawn position using the selected X and Z positions 
    Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

    // Debug logs to check the array length and the random index for carPrefabs
    Debug.Log("carPrefabs length: " + carPrefabs.Length);
    int carIndex = Random.Range(0, carPrefabs.Length);
    Debug.Log("Random index for car prefab: " + carIndex);

    // Randomly choose one of the car prefabs from the carPrefabs array
    GameObject spawnedCar = Instantiate(carPrefabs[carIndex], spawnPos, carPrefabs[carIndex].transform.rotation);

    // Assign the "Car" tag to the spawned car to help with collision detection 
    spawnedCar.tag = "Car";
    UpdateScore(5);
}

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;


    }
public void GameOver()
{
    //game over
    Debug.Log("GameOver method.");
    gameOver.gameObject.SetActive(true);
}
}

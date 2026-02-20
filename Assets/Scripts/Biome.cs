using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Biome : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    float timer = 0f;
    float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        // Create the enemy and set it to follow and attack the player
        GameObject newEnemy = Instantiate(enemy); // Create the enemy
        newEnemy.transform.position = position; // Set the enemy's position
        //newEnemy.GetComponent<Enemy>().InitializeEnemy(enemyData, position, player, this); // Initialize the enemy scripts
        newEnemy.transform.parent = transform; // Set's the enemy to be a child of this object. Keeps the scene hierarchy clean.
    }

    public Vector3 GenerateRandomPosition()
    {
        float x, y;

        x = UnityEngine.Random.Range(-this.transform.localScale.x / 2, this.transform.localScale.x / 2);
        y = UnityEngine.Random.Range(-this.transform.localScale.y / 2, this.transform.localScale.y / 2);

        // Sets up the vector for enemies to spawn on
        Vector3 position = new Vector3(x, y, 0f);

        // Sets the enemy's position to be relative to the biome
        position += this.transform.position;

        return position;
    }
}

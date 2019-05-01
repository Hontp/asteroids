using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // store spawn point position
    private List<Transform> spawnPos = new List<Transform>();

    [SerializeField]
    private float waitTime;

    // the maxium asteroid on screen at one time
    [SerializeField]
    private int maxAsteroid = 10;

    // number of asteroid currently
    private int asteroidCounter = 0;


    // spawn timer
    private float timer = 0;

    /// <summary>
    /// Initilize the spwan point list and create the asteroid object
    /// </summary>
    private void Start()
    {
        // initialize spawn pooint transform
        foreach ( Transform point in transform)
        {
            spawnPos.Add(point);
        }

        // create asteroid
        Utilities.Instance.CreateGameObject("asteroid", "prefab/asteroid/asteroid");

        // create the asteroid fragment object, the spawner doesnt spawn these directly
        Utilities.Instance.CreateGameObject("fragment", "prefab/asteroid/medAsteroid");

        // time until next spawn
        waitTime = Random.Range(1.0f, 1.5f);
    }

    /// <summary>
    /// spawm the asteroid objects
    /// </summary>
    private void SpawnAsteroid()
    {

        if (asteroidCounter < maxAsteroid)
        {

            GameObject asteroid = null;

            // randomly choose a spawn point
            int locationIndex = Random.Range(0, 4);

            // rnadom movement speed
            float speed = Random.Range(10.0f, 25.0f);

            // random rotation speed
            float rotation = Random.Range(5.0f, 30.0f);

            if (spawnPos[locationIndex].name == "spawnLeft")
            {

                // instantiate the asteroid object
                Utilities.Instance.InstantiateGameObject(ref asteroid, "asteroid",
                    spawnPos[locationIndex].position, spawnPos[locationIndex].rotation);

                // give the asteroid a random force speed
                asteroid.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * speed);

                // add random rotation
                asteroid.GetComponent<Rigidbody2D>().AddTorque(rotation * -spawnPos[locationIndex].rotation.x * Time.deltaTime);
            }
            else if (spawnPos[locationIndex].name == "spawnRight")
            {
                // instantiate the asteroid object
                Utilities.Instance.InstantiateGameObject(ref asteroid, "asteroid",
                    spawnPos[locationIndex].position, spawnPos[locationIndex].rotation);

                // give the asteroid a random force speed
                asteroid.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * speed);

                // add random rotation
                asteroid.GetComponent<Rigidbody2D>().AddTorque(rotation * -spawnPos[locationIndex].rotation.x * Time.deltaTime);
            }
            else if (spawnPos[locationIndex].name == "spawnTop")
            {
                // instantiate the asteroid object
                Utilities.Instance.InstantiateGameObject(ref asteroid, "asteroid",
                    spawnPos[locationIndex].position, spawnPos[locationIndex].rotation);

                // give the asteroid a random force speed
                asteroid.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.down * speed);

                //add rnadom rotation
                asteroid.GetComponent<Rigidbody2D>().AddTorque(rotation * -spawnPos[locationIndex].rotation.y * Time.deltaTime);
            }
            else if (spawnPos[locationIndex].name == "spawnDown")
            {
                // instantiate the asteroid object
                Utilities.Instance.InstantiateGameObject(ref asteroid, "asteroid",
                    spawnPos[locationIndex].position, spawnPos[locationIndex].rotation);

                // give the asteroid a random force speed
                asteroid.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * speed);

                // add random rotation
                asteroid.GetComponent<Rigidbody2D>().AddTorque(rotation * -spawnPos[locationIndex].rotation.y * Time.deltaTime);
            }


            asteroidCounter++;

        }

    }

    /// <summary>
    /// spawn asteroids based on the timer
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;

        if ( timer > waitTime)
        {
            
            // spawn asteroids
            SpawnAsteroid();


            timer = -15;
        }

    }
}

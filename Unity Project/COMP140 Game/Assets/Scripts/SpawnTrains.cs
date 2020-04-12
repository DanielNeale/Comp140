using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrains : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trains = null;
    [SerializeField]
    private Transform[] spawnPoints = null;

    private float currentTime;
    private float timer;

    void Start()
    {
        currentTime = 25;
        timer = currentTime - 20;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Transform newSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject newTrain = trains[Random.Range(0, trains.Length)];

            GameObject train = Instantiate(newTrain, newSpawn.position, newSpawn.rotation);
            train.GetComponent<TrainController>().initialisation(2, gameObject);

            if (currentTime > 3)
            {
                currentTime -= 0.2f;
            }
            
            timer = currentTime;
        }
    }
}

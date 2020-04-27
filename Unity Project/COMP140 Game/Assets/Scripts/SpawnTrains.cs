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
    private bool spawn;
    private float trainSpeed;

    void Start()
    {
        trainSpeed = 1.5f;
        currentTime = 20;
        timer = currentTime - 15;
    }

    void Update()
    {
        if (spawn)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                Transform newSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject newTrain = trains[Random.Range(0, trains.Length)];

                GameObject train = Instantiate(newTrain, newSpawn.position, newSpawn.rotation);
                train.GetComponent<TrainController>().initialisation(trainSpeed, gameObject);

                if (currentTime > 3)
                {
                    currentTime -= 0.5f;
                }

                if (trainSpeed < 3)
                {
                    trainSpeed += 0.05f;
                }

                timer = currentTime;
            }       
        }
    }

    
    public void setSpawn(bool newSpawn)
    {
        spawn = newSpawn;
    }
}

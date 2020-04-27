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


    /// <summary>
    /// Spawns a train everytime a timer gets to zero
    /// </summary>
    void Update()
    {
        if (spawn)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                //Gets a random spawn point and train colour
                Transform newSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject newTrain = trains[Random.Range(0, trains.Length)];

                //Spawns the new train and sets its speed and the controller
                GameObject train = Instantiate(newTrain, newSpawn.position, newSpawn.rotation);
                train.GetComponent<TrainController>().initialisation(trainSpeed, gameObject);

                //Reduces the time until the next train spawns
                if (currentTime > 3)
                {
                    currentTime -= 0.5f;
                }

                //Increases the speed of the next train
                if (trainSpeed < 3)
                {
                    trainSpeed += 0.05f;
                }

                timer = currentTime;
            }       
        }
    }

    
    /// <summary>
    /// Sets if trains should be spawning
    /// </summary>
    public void setSpawn(bool newSpawn)
    {
        spawn = newSpawn;

        //Resets train spawning variables
        if (spawn)
        {
            trainSpeed = 1.5f;
            currentTime = 20;
            timer = currentTime - 15;
        }
    }
}

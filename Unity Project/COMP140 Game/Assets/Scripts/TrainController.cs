using UnityEngine;

public class TrainController : MonoBehaviour
{
    private float speed;
    private Transform target;
    private GameObject controller;


    /// <summary>
    /// Sets the speed and the controller for the train
    /// </summary>
    /// <param name="newSpeed"></param>
    /// The trains speed
    /// <param name="newController"></param>
    /// The game controller so the train can add score or take life when it exits
    public void initialisation(float newSpeed, GameObject newController)
    {
        speed = newSpeed;
        controller = newController;
    }


    /// <summary>
    /// Moves the train forward
    /// </summary>
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


    /// <summary>
    /// Handles the trains collision
    /// </summary>
    /// <param name="collision"></param>
    /// Information about the collision
    private void OnTriggerEnter(Collider collision)
    {
        // Is the end of the track and checks to see if the exit is correct
        // to either add score or take a life
        if (collision.gameObject.layer == 10)
        {
            if (collision.transform.tag == transform.tag)
            {
                controller.GetComponent<Score>().AddScore(1);
            }

            else
            {
                controller.GetComponent<Score>().TakeLife();
            }
        }

        //Is a new rail and changes the target direction of the train
        else
        {
            target = collision.transform.GetChild(0).transform;
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPos);
        }
    }
}

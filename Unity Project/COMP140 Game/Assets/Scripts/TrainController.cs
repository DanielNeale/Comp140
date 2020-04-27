using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    private float speed;
    private Transform target;
    private GameObject controller;


    public void initialisation(float newSpeed, GameObject newController)
    {
        speed = newSpeed;
        controller = newController;
    }


    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


    private void OnTriggerEnter(Collider collision)
    {
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

        else
        {
            target = collision.transform.GetChild(0).transform;
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPos);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    private Transform target;

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
                Debug.Log("yes");
            }

            else
            {
                Debug.Log("no");
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

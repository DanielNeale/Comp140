using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private Transform startPos = null;
    private Transform target;

    void Start()
    {
        transform.position = startPos.position;
        
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        target = collision.transform.GetChild(0).transform;
        transform.LookAt(target);
    }
}

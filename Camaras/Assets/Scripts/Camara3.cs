using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara3 : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] bool stop = false;
    [SerializeField] bool general = true;

    void Update()
    {
        if (!stop)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
            Camera.main.focalLength += 5f * Time.deltaTime * speed;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("General"))
        {
            stop = true;
        }
    }
}

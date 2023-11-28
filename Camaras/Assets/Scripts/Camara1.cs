using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara1 : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] bool moveFoward = true;
    [SerializeField] bool moveBackward = false;
    [SerializeField] bool general = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.A))
        {
            if (general)
            {
                general = false;
                moveBackward = true;
            }
            else
            {
                general = true;
                moveFoward = true;
            }
        }

        if (moveFoward && general)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (moveBackward && !general)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("3Persona"))
        {
            moveFoward = false;
            moveBackward = true;
        }

        if (other.CompareTag("General"))
        {
            moveFoward = true;
            moveBackward = false;
        }
    }
    
}

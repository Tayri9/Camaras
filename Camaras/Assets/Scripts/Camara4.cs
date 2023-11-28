using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara4 : MonoBehaviour
{
    [Header("Travelling")]
    [SerializeField] float speedTrav = 5.0f;
    [SerializeField] bool stopTrav = false;

    [Header("Rotacion")]
    [SerializeField] float rotY = 135f;
    [SerializeField] float speedRot = 100f;
    [SerializeField] float posIni = 90f;
    [SerializeField] float posFin = 155f;
    [SerializeField] bool canRotate = false;

    [Header("Vertigo")]
    [SerializeField] bool stopVer = false;
    [SerializeField] float speedVer = 1.0f;
    [SerializeField] float focalLength;

    void Start()
    {
        
    }

    void Update()
    {
        if (!stopVer)
        {
            transform.position -= transform.forward * Time.deltaTime * speedVer;
            Camera.main.focalLength += 5f * Time.deltaTime * speedVer;
        }

        if (canRotate)
        {
            Camera.main.transform.Rotate(0, 0.1f * Time.deltaTime * speedRot, 0);

            if (gameObject.transform.rotation.eulerAngles.y >= posFin)
            {
                canRotate = false;
                Camera.main.transform.rotation = Quaternion.Euler(0, rotY, 0);
                stopTrav = false;
                Camera.main.focalLength = focalLength;
            }
        }

        if (!stopTrav)
        {
            transform.position += transform.forward * Time.deltaTime * speedVer;
            Camera.main.focalLength -= 5f * Time.deltaTime * speedVer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("General"))
        {
            stopVer = true;
            focalLength = Camera.main.focalLength;
            canRotate = true;
            Camera.main.transform.rotation = Quaternion.Euler(0, posIni, 0);
            Camera.main.focalLength = 24;
        }

        if (other.CompareTag("3Persona"))
        {
            stopTrav = true;
        }
    }

    /*void Update()
    {
        if (!stopTrav)
        {
            transform.position -= transform.forward * Time.deltaTime * speedTrav;
        }

        if (canRotate)
        {
            Camera.main.transform.Rotate(0, 0.1f * Time.deltaTime * speedRot, 0);

            if (gameObject.transform.rotation.eulerAngles.y >= posFin)
            {
                canRotate = false;
                Camera.main.transform.rotation = Quaternion.Euler(0, rotY, 0);
                stopVer = false;
            }
        }

        if (!stopVer)
        {
            transform.position += transform.forward * Time.deltaTime * speedVer;
            Camera.main.focalLength -= 5f * Time.deltaTime * speedVer;
        }

        if (!stopVer2)
        {
            transform.position -= transform.forward * Time.deltaTime * speedVer;
            Camera.main.focalLength += 5f * Time.deltaTime * speedVer;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("General"))
        {
            stopTrav = true;
            canRotate = true;
            Camera.main.transform.rotation = Quaternion.Euler(0, posIni, 0);
            stopVer2 = true;
        }

        if (other.CompareTag("3Persona"))
        {
            stopVer = true;
            stopVer2 = false;
        }
    }*/
}

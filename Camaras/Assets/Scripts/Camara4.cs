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
    [SerializeField] float speedRot = 50f;
    [SerializeField] float posIni = 90f;
    [SerializeField] float posFin = 155f;
    [SerializeField] bool canRotateRight = false;
    [SerializeField] bool canRotateLeft = false;

    [Header("Vertigo")]
    [SerializeField] bool stopVer = false;
    [SerializeField] float speedVer = 1.0f;
    [SerializeField] bool aumentarFocal = false;
    [SerializeField] bool disminuirFocal = false;
    [SerializeField] float maxFocal = 69;
    [SerializeField] float minFocal = 43;

    void Start()
    {
        //43 69
    }

    void Update()
    {
        if (!stopVer)
        {
            transform.position -= transform.forward * Time.deltaTime * speedVer;
            Camera.main.focalLength += 5f * Time.deltaTime * speedVer;
        }

        if (disminuirFocal)
        {
            Camera.main.focalLength -= 5f * Time.deltaTime * speedVer;
            if(Camera.main.focalLength <= minFocal)
            {
                disminuirFocal = false;
                canRotateRight = true;                
            }
        }

        if (canRotateRight)
        {
            Camera.main.transform.Rotate(0, 0.1f * Time.deltaTime * speedRot, 0);

            if (gameObject.transform.rotation.eulerAngles.y >= posFin)
            {
                canRotateRight = false;
                canRotateLeft = true;
            }
        }

        if (canRotateLeft)
        {
            Camera.main.transform.Rotate(0, -0.1f * Time.deltaTime * speedRot, 0);

            if (gameObject.transform.rotation.eulerAngles.y <= rotY)
            {
                canRotateLeft = false;
                aumentarFocal = true;
            }
        }

        if (aumentarFocal)
        {
            Camera.main.focalLength += 5f * Time.deltaTime * speedVer;
            if (Camera.main.focalLength >= maxFocal)
            {
                aumentarFocal = false;
                stopTrav = false;
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
            disminuirFocal = true;
        }

        if (other.CompareTag("3Persona"))
        {
            stopTrav = true;
        }
    }

    
}

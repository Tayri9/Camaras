using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara1 : MonoBehaviour
{    
    [SerializeField] bool general = true;
    [SerializeField] bool limit = false;
    [SerializeField] float speed = 0.2f;
    [SerializeField] float fieldOfView = 70;
    [SerializeField] float fieldOfViewGeneral = 70;
    [SerializeField] float fieldOfViewTercera = 25;

    void Start()
    {
        Camera.main.fieldOfView = fieldOfViewGeneral;
        general = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (general)
            {
                fieldOfView = 25;
                general = false;
                limit = true;
            }
            else
            {
                fieldOfView = 70;
                general = true;
                limit = true;
            }
        }

        if (limit && general)
        {
            fieldOfView-=speed;
            Camera.main.fieldOfView = fieldOfView;

            if (fieldOfView <= fieldOfViewTercera)
            {
                limit = false;
            }
        }
        else if (limit && !general)
        {
            fieldOfView+=speed;
            Camera.main.fieldOfView = fieldOfView;

            if (fieldOfView >= fieldOfViewGeneral)
            {
                limit = false;
            }
        }
    }
}

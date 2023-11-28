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

    /*[SerializeField] float speed = 2f;
    [SerializeField] Vector3 posicionCamara;
    [SerializeField] Vector3 posicionPlanoGeneral = new Vector3(-18.52f, 4.83f, -16.32f);
    [SerializeField] Vector3 posicionTerceraPersona = new Vector3(-8.14f, 2.6f, -16.32f);*/
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.fieldOfView = fieldOfViewGeneral;
        general = true;
    }

    // Update is called once per frame
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

            if (fieldOfView < fieldOfViewTercera)
            {
                limit = false;
            }
        }
        else if (limit && !general)
        {
            fieldOfView+=speed;
            Camera.main.fieldOfView = fieldOfView;

            if (fieldOfView > fieldOfViewGeneral)
            {
                limit = false;
            }
        }
        //Camera.main.fieldOfView = fieldOfView;
    }

    /*
     * posicionCamara = gameObject.GetComponent<Transform>().position;

        if (Input.GetMouseButtonDown(0))
        {
            if (general)
            {
                general = false;
            }
            else
            {             
                general = true;
            }
        }

        if (general)
        {
            transform.Translate(0f, 0.1f * Time.deltaTime * speed, 0.1f * Time.deltaTime * speed);
            
        }
        else
        {
            transform.Translate(0f, -0.1f * Time.deltaTime * speed, -0.1f * Time.deltaTime * speed);
            
        }
    */
}

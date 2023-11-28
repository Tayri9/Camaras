using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] float posIni = 90f;
    [SerializeField] float posFin = 175f;
    [SerializeField] bool canRotate = true;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.rotation = Quaternion.Euler(0, posIni, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            Camera.main.transform.Rotate(0, 0.1f * Time.deltaTime * speed, 0);

            if(gameObject.transform.rotation.eulerAngles.y >= posFin)
            {
                canRotate = false;
            }
        }        
    }
}

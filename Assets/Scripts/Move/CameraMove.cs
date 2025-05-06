using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trida pro pohyb kamery pomoci mysi
public class CameraMove : MonoBehaviour
{
    //Promenne pro zachovani uhlu rotace
    float osa_x;
    float osa_y;
    //Instance objektu hrace
    public GameObject player;
    //Citlivost mysi
    float mouseSensitive = 12;

    void Start()
    {
        
    }

    
    void Update()
    {
        //Vertikalni pohyb
        osa_x -= Input.GetAxis("Mouse Y") * mouseSensitive;
        //Horizontalni pohyb
        osa_y += Input.GetAxis("Mouse X") * mouseSensitive;

        //Omezeni rozsahu rotace v ose x aby nesla za pozadovany uhel
        osa_x = Mathf.Clamp(osa_x, 335, 420);

        //Nastaveni rotace kamery
        transform.localEulerAngles = new Vector3(osa_x, 0, 0);
        player.transform.localEulerAngles = new Vector3(0, osa_y, 0);

    }
}

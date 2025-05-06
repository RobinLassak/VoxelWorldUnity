using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        //Ulozeni komponenty pro pohyb hrace do promenne
        rb = transform.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Tento objekt nema pripojeny rigidbody!");
        }
        
        
    }

    
    void Update()
    {
        //Pohyb hrace pomoci tlacitek W,A,S,D
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddRelativeForce(new Vector3(5, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddRelativeForce(new Vector3(-5, 0, 0));
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddRelativeForce(new Vector3(0, 0, 5));
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddRelativeForce(new Vector3(5, 0, -5));
            } 
        }

    }
}

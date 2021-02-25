using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float gravity;
    public int turn;
    public float fuel;
    public bool isGrounded;
    void Start()
    {
        force = 1000;
        gravity = 300;
        turn = 90;
        fuel = 10;
        rb = transform.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0, -gravity*Time.fixedDeltaTime,0);
        if (Input.GetKey("space") && fuel>0)
        {
            rb.AddRelativeForce(0, force * Time.fixedDeltaTime, 0);
            fuel -= 4 * Time.deltaTime;
        }

        if (Input.GetKey("d")&&isGrounded==false)
        {
            transform.Rotate(0,0,-turn*Time.fixedDeltaTime);
        }
        if (Input.GetKey("a")&&isGrounded==false)
        {
            transform.Rotate(0,0,turn*Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down,  0.8f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}

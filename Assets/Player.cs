using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 lastPos;
    public float timer=-1;
    public float force;
    public float gravity;
    public int turn;
    public float fuel;
    public bool isGrounded;
    private void Start()
    {
        force = 1000;
        gravity = 300;
        turn = 90;
        fuel = 10;
        rb = GetComponent<Rigidbody>();
        lastPos = rb.position;
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
    private void  Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down,  0.8f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        speed = (rb.position - lastPos).magnitude/Time.deltaTime;
        lastPos = rb.position;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //обработка таймера, необходимо, чтобы ракета стояла на месте приземления около секунды
        }
        
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (speed>15)
        {
            Debug.Log("YouFailed");
            return;
        }
        if (collisionInfo.collider.name == "PlatformFinal"&&Math.Abs(rb.rotation.z-collisionInfo.gameObject.transform.rotation.z)<=0.20)
        {
            timer = 1000;
        }
    }
}

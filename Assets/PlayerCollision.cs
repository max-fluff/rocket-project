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
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPos = rb.position;
    }

    private void  FixedUpdate()
    {
        speed = (rb.position - lastPos).magnitude/Time.fixedDeltaTime;
        lastPos = rb.position;
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
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

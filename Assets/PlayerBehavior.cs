using System;
using UnityEngine;
using UnityEngine.Internal.VR;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Vector3 collUndockedSize;
    public Vector3 collUndockedCenter;
    public float speed;
    public Vector3 lastPos;
    public float timer;
    public float force;
    public float gravity;
    public int turn;
    public float fuel;
    public bool isGrounded;
    public bool isLanded;
    public bool isUndocked=true;
    public bool isDoubleDocked=true;
    private void Start()
    {
        force = 1000;
        gravity = 200;
        timer = 3;
        collUndockedSize=new Vector3(1,2,1);
        collUndockedCenter=new Vector3(0,0,0);
        rb = GetComponent<Rigidbody>();
        if(isDoubleDocked==true)
        {
            rb.mass = 2;
            fuel = 20;
            isUndocked = false;
            turn = 45;
        }
        else
        {
            rb.mass = 1;
            fuel = 10;
            turn = 90;
        }
        coll = GetComponent<BoxCollider>();
        lastPos = rb.position;
    }
    void FixedUpdate()
    {
        rb.AddForce(0, -gravity*Time.fixedDeltaTime,0);
        if (Input.GetKey("space") && fuel>0)
        {
            rb.AddRelativeForce(0, force * Time.fixedDeltaTime, 0);
            fuel -= 4 * Time.deltaTime;
            if(fuel<=10&&isUndocked==false)
                Undock();
        }
        if (Input.GetKey("d")&&isGrounded==false)
            transform.Rotate(0,0,-turn*Time.fixedDeltaTime);
        if (Input.GetKey("a")&&isGrounded==false)
            transform.Rotate(0,0,turn*Time.fixedDeltaTime);
        speed = (rb.position - lastPos).magnitude/Time.fixedDeltaTime;
        lastPos = rb.position;
    }
    private void  Update()
    {
        if (Physics.Raycast(transform.position-coll.bounds.size/2*(isUndocked ? 0:1), -transform.up,  1.2f))
            isGrounded = true;
        else
            isGrounded = false;
        if (isLanded && isGrounded)
            timer -= Time.deltaTime;
        else
            timer = 1;
        if (timer <= 0)
            Debug.Log("YouWin");
    }

    void Undock()
    {
        coll.size = collUndockedSize;
        coll.center = collUndockedCenter;
        rb.mass = 1;
        isUndocked = true;
        turn = 90;
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        float inclination =Math.Abs(rb.rotation.z - collisionInfo.gameObject.transform.rotation.z);
        if (speed>15||(speed>5&&inclination>=0.25)||inclination>=0.7)
        {
            Debug.Log("YouFailed");
            return;
        }
        if (collisionInfo.collider.name == "PlatformFinal"&&inclination<=0.25)
            isLanded = true;
        else
            isLanded = false;
    }
}

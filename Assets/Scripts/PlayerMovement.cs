using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _lastPos;
    private static float _force;
    [SerializeField] public PlayerState player;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _force = 1000;
    }
    
    void FixedUpdate()
    {
        if(player.Fuel > 0&&player.Delay<=0&&!player.isBlown)
        {
            if (Input.GetButton("Fly"))
            {
                _rb.AddRelativeForce(0, _force * Time.fixedDeltaTime, 0);
                player.DrainFuel(4 * Time.deltaTime);
                player.SetThrottleEmission(50);
            }
            else
            {
                player.SetThrottleEmission(0);
            }
            if (Math.Abs(Input.GetAxis("Horizontal")) > 0.001f)
            {
                _rb.AddTorque(-transform.forward * (player.Turn * Input.GetAxis("Horizontal")));
                player.DrainFuel(1*Time.fixedDeltaTime);
            }
            if (player.Fuel <= player.fullFuel && player.IsUndocked == false)
                player.Undock();
        }
        else
        {
            player.CountDelay(Time.fixedDeltaTime); 
            player.SetThrottleEmission(0);
        }

        player.Speed = GetComponent<Rigidbody>().velocity.magnitude;
    }
}

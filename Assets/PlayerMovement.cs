using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _lastPos;
    private static float _speed;
    private static float _force;
    private static int _turn;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _force = 1000;
        Physics.gravity = new Vector3(0, -2F, 0);
        if(PlayerState.IsDoubleDocked())
        {
            _rb.mass = 2;
            _turn = 45;
        }
        else
        {
            _rb.mass = 1;
            _turn = 90;
        }
        _lastPos = _rb.position;
    }

    public static float GetSpeed()
    {
        return _speed;
    }
    public static void SetTurn(int turn)
    {
        _turn=turn;
    }
    void FixedUpdate()
    {

        if(PlayerState.GetFuel() > 0&&PlayerState.GetDelay()<=0)
        {
            if (Input.GetKey("space"))
            {
                _rb.AddRelativeForce(0, _force * Time.fixedDeltaTime, 0);
                PlayerState.DrainFuel(4 * Time.deltaTime);
                if (PlayerState.GetFuel() <= 10f && PlayerState.IsUndocked() == false)
                    PlayerState.Undock();
            }

            if (Input.GetKey("d") && PlayerState.IsGrounded() == false)
                transform.Rotate(0, 0, -_turn * Time.fixedDeltaTime);
            if (Input.GetKey("a") && PlayerState.IsGrounded() == false)
                transform.Rotate(0, 0, _turn * Time.fixedDeltaTime);
        }
        else
            PlayerState.CountDelay(Time.fixedDeltaTime);
        _speed = (_rb.position - _lastPos).magnitude/Time.fixedDeltaTime;
        _lastPos = _rb.position;
    }
}

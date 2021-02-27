using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private float _landedPosTimer;
    private static float _delay=0;
    private static float _fuel;
    private static bool _isGrounded;
    private static bool _isLanded;
    private static bool _isUndocked;
    private static bool _isDoubleDocked;
    private static Rigidbody _rb;
    private static BoxCollider _coll;
    void Start()
    {
        _landedPosTimer = 3f;
        _isUndocked = true;
        _isDoubleDocked = true;
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<BoxCollider>();
        if(_isDoubleDocked)
        {
            _rb.mass = 2;
            _fuel = 20;
            _isUndocked = false;
        }
        else
        {
            _rb.mass = 1;
            _fuel = 10;
        }
    }
    private void  Update()
    {
        if (Physics.Raycast(transform.position-_coll.bounds.size/2*(_isUndocked ? 0:1), -transform.up,  1.2f))
            _isGrounded = true;
        else
            _isGrounded = false;
        if (_isLanded && _isGrounded)
            _landedPosTimer -= Time.deltaTime;
        else
            _landedPosTimer = 3f;
        if (_landedPosTimer <= 0)
            Debug.Log("YouWin");
    }
    public static void Undock()
    {
        _coll.size = PlayerCollision.GetUndockedSize();
        _coll.center = PlayerCollision.GetUndockedCenter();;
        _rb.mass = 1;
        _isUndocked = true;
        PlayerMovement.SetTurn(90);
        _delay = 0.8f;
    }

    public static bool IsUndocked()
    {
        return _isUndocked;
    }
    public static bool IsDoubleDocked()
    {
        return _isDoubleDocked;
    }
    public static void SetLanded(bool isLanded)
    {
        _isLanded=isLanded;
    }
    public static bool IsGrounded()
    {
        return _isGrounded;
    }
    public static float GetFuel()
    {
        return _fuel;
    }
    public static float GetDelay()
    {
        return _delay;
    }
    public static void CountDelay(float time)
    {
        _delay -= time;
    }
    public static void DrainFuel(float amount)
    {
        _fuel -= amount;
    }
    
}

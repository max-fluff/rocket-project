using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class PlayerState : MonoBehaviour
{
    public float LandedPosTimer { set; get; }
    public float Delay { set; get; }
    public float Fuel { set; get; }
    public bool IsGrounded { set; get; }
    public bool IsLanded { set; get; }
    public bool IsUndocked { set; get; }
    public Rigidbody RB { set; get; }
    public BoxCollider Coll { set; get; }
    public float Speed { set; get; }
    public float Turn { set; get; }
    private void  Update()
    {
        IsGrounded = Physics.Raycast(transform.position-(IsUndocked ? 0 : -2) * -transform.up, -transform.up,  1.1f);
        if (IsLanded && IsGrounded)
            LandedPosTimer -= Time.deltaTime;
        else
            LandedPosTimer = 3f;
        if (LandedPosTimer <= 0)
        {
            Debug.Log("YouWin");
            LandedPosTimer = 0;
        }
        //Сделать обработчик сцен и отправить туда vvv
        if (Input.GetButtonDown("Restart Level"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void CountDelay(float time)
    {
        Delay -= time;
    }
    public void DrainFuel(float amount)
    {
        Fuel -= amount;
    }
    public abstract void Undock();
}

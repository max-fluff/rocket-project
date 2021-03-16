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
    protected Rigidbody Rb { set; get; }
    protected BoxCollider Coll { set; get; }
    public float Speed { set; get; }
    public float Turn { set; get; }
    public float fullFuel = 10;
    public SceneManagement sceneManagement;
    protected ParticleSystem.EmissionModule ThrottleEmission;
    [SerializeField]public ParticleSystem fireLeft;
    [SerializeField]public ParticleSystem fireRight;
    private void  Update()
    {
        IsGrounded = Physics.Raycast(transform.position-(IsUndocked ? 0 : -2) * -transform.up, -transform.up,  1.1f);
        if (IsLanded && IsGrounded)
            LandedPosTimer -= Time.deltaTime;
        else
            LandedPosTimer = 3f;
        if (LandedPosTimer <= 0)
        {
            sceneManagement.NextScene();
            LandedPosTimer = 0;
        }
        if (Input.GetButtonDown("Restart Level"))
        {
            sceneManagement.SceneRestart();
        }
        Debug.Log(LandedPosTimer);
    }
    public void CountDelay(float time)
    {
        Delay -= time;
    }
    public void DrainFuel(float amount)
    {
        Fuel -= amount;
    }

    public void SetThrottleEmission(float rate)
    {
        SetEmission(ThrottleEmission,rate);
    }
    public void SetTorqueEmission(float mult)
    {
        if (mult > 0)
        {
            SetEmission(fireLeft.emission,30*mult);
            SetEmission(fireRight.emission,0);
        }
        else
        {
            SetEmission(fireRight.emission,-30*mult);
            SetEmission(fireLeft.emission,0);
        }
    }
    private void SetEmission(ParticleSystem.EmissionModule emission, float rate)
    {
        emission.rateOverTime = rate;
    }
    public abstract void Undock();
}

using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    public float LandedPosTimer { set; get; }
    public float Delay { set; get; }
    public float Fuel { set; get; }
    public bool IsGrounded { set; get; }
    public bool IsLanded { set; get; }
    public bool IsUndocked { set; get; }
    protected Rigidbody Rb { set; get; }
    public float Speed { set; get; }
    public float Turn { set; get; }
    public bool isBlown { set; get; }
    public float fullFuel = 10;
    [SerializeField] private SceneManagement sceneManagement;
    protected ParticleSystem.EmissionModule ThrottleEmission;
    private void  Update()
    {
        IsGrounded = Physics.Raycast(transform.position-(IsUndocked ? 0 : -2) * -transform.up, -transform.up,  0.5f);
        if (IsLanded && IsGrounded)
            LandedPosTimer -= Time.deltaTime;
        else
            LandedPosTimer = 3f;
        if (LandedPosTimer <= 0)
        {
            sceneManagement.LevelPassed();
            LandedPosTimer = 0;
        }
        if (Input.GetButtonDown("Restart Level"))
        {
            sceneManagement.SceneRestart();
        }
    }
    public void CountDelay(float time)
    {
        Delay -= time;
    }
    public void DrainFuel(float amount)
    {
        Fuel -= amount;
        if (Fuel > fullFuel + fullFuel * (IsUndocked ? 0 : 1))
        {
            Fuel = fullFuel + fullFuel * (IsUndocked ? 0 : 1);
        }
    }

    public void SetThrottleEmission(float rate)
    {
        SetEmission(ThrottleEmission, rate);
    }
    private void SetEmission(ParticleSystem.EmissionModule emission, float rate)
    {
        emission.rateOverTime = rate;
    }
    public abstract void Undock();
}

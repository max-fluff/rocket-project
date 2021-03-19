using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleDockedState : PlayerState
{
    private void Start()
    {
        LandedPosTimer = 3f;
        IsUndocked = true;
        Rb = GetComponent<Rigidbody>();
        Rb.mass = 1;
        Fuel = fullFuel;
        Turn = 90*Time.fixedDeltaTime;
        ParticleSystem fire =  GameObject.Find("FireMain").GetComponent<ParticleSystem>();
        ThrottleEmission = fire.emission;
    }

    public override void Undock() {}
}

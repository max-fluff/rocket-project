using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoubleDockedState : PlayerState
{
    private void Start()
    {
        LandedPosTimer = 3f;
        Rb = GetComponent<Rigidbody>();
        Coll = GetComponent<BoxCollider>();
        Rb.mass = 2;
        Fuel = 2*fullFuel;
        IsUndocked = false;
        Coll.size = new Vector3(1,4,1);
        Coll.center = new Vector3(0,-1,0);
        Turn = 180*Time.fixedDeltaTime;
        ParticleSystem fire =  GameObject.Find("FirePart").GetComponent<ParticleSystem>();
        ThrottleEmission = fire.emission;
    }
    public override void Undock()
    {
        Coll.size = new Vector3(1,2,1);
        Coll.center = new Vector3(0,0,0);
        Rb.mass = 1;
        IsUndocked = true;
        Turn = 90*Time.fixedDeltaTime;
        Delay = 0.8f;
        SetThrottleEmission(0);
        ParticleSystem fire =  GameObject.Find("FireMain").GetComponent<ParticleSystem>();
        ThrottleEmission = fire.emission;
    }

}
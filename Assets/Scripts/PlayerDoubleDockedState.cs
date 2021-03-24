using UnityEngine;

public class PlayerDoubleDockedState : PlayerState
{
    [SerializeField] private GameObject ColliderDouble; 
    [SerializeField] private GameObject ColliderSingle; 
    private void Start()
    {
        LandedPosTimer = 3f;
        Rb = GetComponent<Rigidbody>();
        Rb.mass = 2;
        Fuel = 2*fullFuel;
        IsUndocked = false;
        Turn = 180*Time.fixedDeltaTime;
        ParticleSystem fire =  GameObject.Find("FirePart").GetComponent<ParticleSystem>();
        ColliderSingle.SetActive(false);
        ThrottleEmission = fire.emission;
    }
    public override void Undock()
    {
        Rb.mass = 1;
        ColliderDouble.SetActive(false);
        ColliderSingle.SetActive(true);
        IsUndocked = true;
        Turn = 90*Time.fixedDeltaTime;
        Delay = 0.8f;
        SetThrottleEmission(0);
        ParticleSystem fire =  GameObject.Find("FireMain").GetComponent<ParticleSystem>();
        ThrottleEmission = fire.emission;
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleDockedState : PlayerState
{
    private void Start()
    {
        LandedPosTimer = 3f;
        IsUndocked = true;
        Rb = GetComponent<Rigidbody>();
        Coll = GetComponent<BoxCollider>();
        Rb.mass = 1;
        Fuel = fullFuel;
        Coll.size = new Vector3(1,2,1);
        Coll.center = new Vector3(0,0,0);
        Turn = 90*Time.fixedDeltaTime;
        GameObject.Find("Part").SetActive(false);
        ParticleSystem fire =  GameObject.Find("FireMain").GetComponent<ParticleSystem>();
        ThrottleEmission = fire.emission;
    }

    public override void Undock() {}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoubleDockedState : PlayerState
{
    private void Start()
    {
        LandedPosTimer = 3f;
        RB = GetComponent<Rigidbody>();
        Coll = GetComponent<BoxCollider>();
        RB.mass = 2;
        Fuel = 20;
        IsUndocked = false;
        Coll.size = new Vector3(1,4,1);
        Coll.center = new Vector3(0,-1,0);
        Turn = 180*Time.fixedDeltaTime;
    }
    public override void Undock()
    {
        Coll.size = new Vector3(1,2,1);
        Coll.center = new Vector3(0,0,0);
        RB.mass = 1;
        IsUndocked = true;
        Turn = 90*Time.fixedDeltaTime;
        Delay = 0.8f;
    }

    
}
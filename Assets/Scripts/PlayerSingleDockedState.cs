using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSingleDockedState : PlayerState
{
    private void Start()
    {
        LandedPosTimer = 3f;
        IsUndocked = true;
        RB = GetComponent<Rigidbody>();
        Coll = GetComponent<BoxCollider>();
        RB.mass = 1;
        Fuel = 10;
        Coll.size = new Vector3(1,2,1);
        Coll.center = new Vector3(0,0,0);
        Turn = 90*Time.fixedDeltaTime;
        GameObject.Find("Part").SetActive(false);
    }

    public override void Undock() {}
}

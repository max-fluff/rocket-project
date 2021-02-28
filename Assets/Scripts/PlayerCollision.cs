using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private BoxCollider _coll;
    private static Vector3 _collUndockedSize;
    private static Vector3 _collUndockedCenter;
    private Rigidbody _rb;
    void Start()
    {
        _collUndockedSize=new Vector3(1,2,1);
        _collUndockedCenter=new Vector3(0,0,0);
        _coll = GetComponent<BoxCollider>();
        _rb=GetComponent<Rigidbody>();
        if(PlayerState.IsDoubleDocked())
        {
            _coll.size = new Vector3(1,4,1);
            _coll.center = new Vector3(0,-1,0);
        }
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        float inclination =Math.Abs(_rb.rotation.z - collisionInfo.gameObject.transform.rotation.z);
        if ((PlayerMovement.GetSpeed()>15||(PlayerMovement.GetSpeed()>5&&inclination>=0.25)||inclination>=0.7)&&collisionInfo.collider.name != "Part1")
        {
            Debug.Log("YouFailed");
            return;
        }
        if (collisionInfo.collider.name == "PlatformFinal"&&inclination<=0.25)
            PlayerState.SetLanded(true);
        else
            PlayerState.SetLanded(false);
    }

    public static Vector3 GetUndockedSize()
    {
        return _collUndockedSize;
    }
    public static Vector3 GetUndockedCenter()
    {
        return _collUndockedCenter;
    }
}

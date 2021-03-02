using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private BoxCollider _coll;
    private Rigidbody _rb;
    [SerializeField] public PlayerState Player;

    private void Start()
    {
        _rb=GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        float inclination =Math.Abs(_rb.rotation.z - collisionInfo.gameObject.transform.rotation.z);
        if ((Player.Speed>15||(Player.Speed>5&&inclination>=0.25)||inclination>=0.7)&&collisionInfo.collider.name != "Part1")
        {
            Debug.Log("YouFailed");
            return;
        }
        if (collisionInfo.collider.name == "PlatformFinal"&&inclination<=0.25)
            Player.IsLanded=true;
        else
            Player.IsLanded=false;
    }
}

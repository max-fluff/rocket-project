using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCollision : MonoBehaviour
{
    private BoxCollider _coll;
    private Rigidbody _rb;
    [FormerlySerializedAs("Player")] [SerializeField] public PlayerState player;
    public SceneManagement sceneManagement;

    private void Start()
    {
        _rb=GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        var inclination =Math.Abs(_rb.rotation.z - collisionInfo.gameObject.transform.rotation.z);
        if ((player.Speed>15||(player.Speed>5&&inclination>=0.25)||inclination>=0.7))
        {
            sceneManagement.SceneRestart();
            return;
        }
        if (collisionInfo.collider.name == "PlatformFinal"&&inclination<=0.25)
            player.IsLanded=true;
        else
            player.IsLanded=false;
    }
}

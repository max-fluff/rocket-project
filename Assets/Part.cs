using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;

public class Part : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public PlayerState ps;
    private void Start()
    {
        Physics.gravity=new Vector3(0, -2F, 0);
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerState>();
        GetComponent<BoxCollider>().enabled =false;
        GetComponent<Rigidbody>().useGravity=false;
    }

    void Update()
    {
        if (IsUndocked(ps)) return;
        offset = 2 * (-player.transform.up);
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }

    private void FixedUpdate()
    {
        if (!IsUndocked(ps)) return;
        GetComponent<BoxCollider>().enabled =true;
        GetComponent<Rigidbody>().useGravity=true;
    }

    private static bool IsUndocked(PlayerState myPlayerState)
    {
        return PlayerState.IsUndocked();
    }
}
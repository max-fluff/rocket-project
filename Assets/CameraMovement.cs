using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = player.position+offset;
    }
}

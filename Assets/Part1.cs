using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Part : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = player.position;
        transform.rotation = player.rotation;
    }
}

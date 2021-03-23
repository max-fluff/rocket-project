using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FuelBoost : MonoBehaviour
{
    public PlayerState player;
    public float amount=5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "ColliderSingle" && other.gameObject.name != "ColliderDouble") return;
        player.DrainFuel(-amount);
        gameObject.SetActive(false);
    }
}

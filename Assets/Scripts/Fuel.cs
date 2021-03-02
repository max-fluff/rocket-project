using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Slider mainFuel;
    public Slider partFuel;
    [SerializeField] public PlayerState player;

    private void Start()
    {
        if (player is PlayerSingleDockedState)
        {
            partFuel.enabled = false;
        }
    }

    public void FixedUpdate()
    {
        if (player.Fuel >= 9)
        {
            partFuel.value = player.Fuel;
        }
        else
        {
            mainFuel.value = player.Fuel;
        }
    }
}

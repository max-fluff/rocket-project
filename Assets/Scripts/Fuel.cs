using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] private Slider mainFuel;
    [SerializeField] private Slider partFuel;
    [SerializeField] private PlayerState player;

    private void Start()
    {
        partFuel.minValue = player.fullFuel;
        partFuel.maxValue = player.fullFuel*2;
        partFuel.value = player.fullFuel*2;
        mainFuel.maxValue = player.fullFuel;
        mainFuel.value = player.fullFuel;
        if (player is PlayerSingleDockedState)
        {
            partFuel.enabled = false;
        }
    }

    public void Update()
    {
        if (player.Fuel >= player.fullFuel)
        {
            partFuel.value = player.Fuel;
        }
        else
        {
            mainFuel.value = player.Fuel;
        }
    }
}

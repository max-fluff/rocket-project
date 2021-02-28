using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    private static Slider _mainFuel;
    private static Slider _partFuel;

    private void Start()
    {
        _mainFuel = GameObject.Find("FuelMain").GetComponent<Slider>();
        _partFuel = GameObject.Find("FuelPart").GetComponent<Slider>();
        bool doubleDocked = PlayerState.IsDoubleDocked();
        if (!doubleDocked)
        {
            _partFuel.enabled = false;
        }
    }

    public static void SetFuel(float fuel)
    {
        if (fuel >= 9)
        {
            _partFuel.value = fuel;
        }
        else
        {
            _mainFuel.value = fuel;
        }
    }
}

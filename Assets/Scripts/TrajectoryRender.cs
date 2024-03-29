﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.U2D;

public class TrajectoryRender : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LineRenderer lr;
    private float velocity;
    private float angle;
    private int res;
    private float g;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        g=Physics.gravity.y;
        res = 30;
    }
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerState>().Speed > 0.5f)
        {
            lr.enabled = true;
            RenderTraject();
        }
        else
        {
            lr.enabled = false;
        }
    }
    void RenderTraject()
    {
        lr.positionCount=res+1;
        Vector3[] Array = new Vector3[res+1];
        angle = Vector3.SignedAngle(player.GetComponent<Rigidbody>().velocity, (Vector3.right),Vector3.forward)*Mathf.Deg2Rad;
        float maxDist=15f*Math.Sign(player.GetComponent<Rigidbody>().velocity.x);
        for (int i = 0; i <= res; i++)
        {
            float t =  (float) i / res;
            Array[i] = CalcPoint(t,maxDist)+player.transform.position;
        }
        lr.SetPositions(Array);
    }
    Vector3 CalcPoint(float t,float maxDistance)
    {
        float x = t * maxDistance;
        float y =-( x * Mathf.Tan(angle) -
                  (g * x * x) / (2 * player.GetComponent<PlayerState>().Speed * 
                                 Mathf.Cos(angle)* player.GetComponent<PlayerState>().Speed * Mathf.Cos(angle)));
        return new Vector3(x,y,0);
    }
}

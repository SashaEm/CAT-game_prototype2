﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector3 cameraRotation;

    
    void Update()
    {
        transform.position = target.position + cameraOffset;
        transform.LookAt(target.position + cameraRotation);
    }
}
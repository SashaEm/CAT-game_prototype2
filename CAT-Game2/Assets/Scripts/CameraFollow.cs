using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private Vector3 cameraRotation;

    private Transform player;

    private void Start()
    {
        target = GameObject.Find("Player");
        player = target.transform;
    }

    void Update()
    {
        Vector3 position = player.position;
        transform.position = position + cameraOffset;
        transform.LookAt(position + cameraRotation);
    }
}

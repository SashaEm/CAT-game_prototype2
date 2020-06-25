using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnRotation : MonoBehaviour
{
    [SerializeField] private float rotationSens = 10f;

    private Transform pillar;
    private Vector3 mouseStart;
    
    void Awake()
    {
        pillar = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {   
            var rotation = (Input.mousePosition - mouseStart)* rotationSens;
            pillar.Rotate(0f, -rotation.x, 0f);
            mouseStart = Input.mousePosition;
        }

        
    }
}

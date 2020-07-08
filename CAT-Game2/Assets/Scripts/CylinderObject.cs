using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderObject : MonoBehaviour
{
    [SerializeField] private Transform endPointTransform;

    public Transform EndPoint => endPointTransform;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnDespawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset = 40f;

    void Update()
    {
        
        if(transform.position.y + offset <= player.position.y)
        {
            Destroy(gameObject);
        }
    }
}

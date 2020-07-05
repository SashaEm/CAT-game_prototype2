using UnityEngine;

public class ColumnDespawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offset = 40f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(transform.position.z + offset <= player.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}

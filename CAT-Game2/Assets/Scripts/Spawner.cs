using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static float startSpawn = 100f;
    private CylinderObject lastSpawned = null;
    private int columnsSpawned;

    public CylinderObject[] columns;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    [SerializeField] private int maxColumns;
    [SerializeField] private Vector3 offset;
    private int chooser;
    [SerializeField] private float spawnDiff = 200f;

    private void Awake()
    {
        columnsSpawned = 0;
        Instantiate(camera, transform.position, transform.rotation);
        Instantiate(player, transform.position + offset, transform.rotation);
    }

    private void Update()
    {
        if(columnsSpawned < maxColumns)
        {
            this.chooser = Random.Range(0, this.columns.Length);
            SpawnPrefab(columns[chooser]);
            columnsSpawned += 1;
        }
    }

    private void SpawnPrefab(CylinderObject prefab)
    {
        if (lastSpawned == null)
        {
            var newCylinder = Instantiate(prefab, transform.position, transform.rotation);
            lastSpawned = newCylinder;
        }
        else
        {
            var newCylinder = Instantiate(prefab, lastSpawned.EndPoint.position, lastSpawned.EndPoint.rotation);
            lastSpawned = newCylinder;
        }
    }
}

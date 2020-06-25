using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] columns;

    private static float startSpawn = 100f;
    private int chooser;
    [SerializeField] private float spawnDiff = 200f;
    private Vector3 spawnPos;
    private Vector3 spawnRot = new Vector3(90f, 0f, 0f);

    private void Awake()
    {
        this.spawnPos.x = 0f;
        this.spawnPos.y = -3.5f;
    }

    private void Update()
    {
        if(startSpawn < this.spawnDiff * 10 + 15f)
        {
            this.spawnPos.z = startSpawn;
            this.chooser = Random.Range(0, this.columns.Length);

            Instantiate(this.columns[this.chooser], this.spawnPos, Quaternion.Euler(this.spawnRot));
            startSpawn += this.spawnDiff;
        }
    }
}

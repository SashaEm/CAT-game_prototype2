using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    [SerializeField] private CylinderObject cylinderStraightPrefab;
    [SerializeField] private CylinderObject cylinderCurvePrefab;

    private CylinderObject lastSpawned = null;

    public void SpawnStraight() => SpawnPrefab(cylinderStraightPrefab);
    public void SpawnCurved() => SpawnPrefab(cylinderCurvePrefab);

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

using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private float rotationSens = 1f;

    private Transform pillar;
    private Vector3 mouseStart;

    void Awake()
    {
        pillar = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var rotation = (Input.mousePosition - mouseStart) * rotationSens;
            pillar.Rotate(0f, 0f, -rotation.x);
            mouseStart = Input.mousePosition;
        }
    }
}

using UnityEngine;

public class CarPainter : MonoBehaviour
{
    public Mesh carMesh;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<MeshFilter>().mesh = carMesh;
    }
}

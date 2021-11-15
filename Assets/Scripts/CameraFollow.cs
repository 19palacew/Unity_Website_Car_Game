using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject car;
    public float smoothing;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, car.transform.position + new Vector3(10.27f, -car.transform.position.y + 9.36f, -5.62f), smoothing * Time.deltaTime);
    }
}

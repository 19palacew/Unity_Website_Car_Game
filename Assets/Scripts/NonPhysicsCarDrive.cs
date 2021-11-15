using UnityEngine;

public class NonPhysicsCarDrive : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Input.GetAxis("Vertical") * Vector3.forward * speed * Time.deltaTime);
        //transform.Rotate(Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime * new Vector3(0,1,0));
        //rb.AddTorque(Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime * new Vector3(0,1,0));
    }
}

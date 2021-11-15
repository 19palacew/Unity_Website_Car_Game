using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public int bounds;
    private GameObject mCamera;

    private void Start()
    {
        mCamera = Camera.main.transform.gameObject;
    }
    void FixedUpdate()
    {
        if (transform.position.x>bounds)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            mCamera.transform.position = new Vector3(-mCamera.transform.position.x, mCamera.transform.position.y, mCamera.transform.position.z);
        }
        else if (transform.position.x < -bounds)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
            mCamera.transform.position = new Vector3(-mCamera.transform.position.x, mCamera.transform.position.y, mCamera.transform.position.z);
        }
        if (transform.position.z > bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
            mCamera.transform.position = new Vector3(mCamera.transform.position.x, mCamera.transform.position.y, -mCamera.transform.position.z);
        }
        else if (transform.position.z < -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
            mCamera.transform.position = new Vector3(mCamera.transform.position.x, mCamera.transform.position.y, -mCamera.transform.position.z);
        }
    }
}

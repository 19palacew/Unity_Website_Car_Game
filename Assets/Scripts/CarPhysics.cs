using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPhysics : MonoBehaviour
{
    public List<CarAxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    private Vector3 curPos;

    private void Start()
    {
        curPos = transform.position;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float circ = axleInfos[1].leftWheel.radius * 2 * Mathf.PI;
        Vector3 pasPos = curPos;
        curPos = transform.position;
        Vector3 meanPos = curPos - pasPos;
        float speed = (meanPos.magnitude/circ)*360;

        foreach (CarAxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                axleInfo.leftWheelMesh.transform.Rotate(new Vector3(speed, 0, 0));
                axleInfo.rightWheelMesh.transform.Rotate(new Vector3(speed, 0, 0));
                //axleInfo.leftWheelMesh.transform.localRotation = Quaternion.Euler(new Vector3(axleInfo.leftWheelMesh.transform.rotation.x, steering + transform.rotation.y, 0));
                //axleInfo.rightWheelMesh.transform.localRotation = Quaternion.Euler(new Vector3(axleInfo.rightWheelMesh.transform.rotation.x, steering + transform.rotation.y, 0));

            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.leftWheelMesh.transform.Rotate(new Vector3(speed, 0, 0));
                axleInfo.rightWheelMesh.transform.Rotate(new Vector3(speed, 0 ,0));
            }
        }
    }
}

[System.Serializable]
public class CarAxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public GameObject leftWheelMesh;
    public GameObject rightWheelMesh;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

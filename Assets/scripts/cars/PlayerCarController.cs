using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];

    float maxTorque = 100;
    float maxAngle = 30;
    float addAcc = 1.5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            wheels[0].motorTorque = maxTorque * Input.GetAxis("Vertical");
            wheels[1].motorTorque = maxTorque * Input.GetAxis("Vertical");
            rb.velocity += transform.forward * addAcc * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            wheels[0].motorTorque = maxTorque * Input.GetAxis("Vertical");
            wheels[1].motorTorque = maxTorque * Input.GetAxis("Vertical");
            rb.velocity -= transform.forward * addAcc * Time.deltaTime;
        }
        wheels[0].steerAngle = maxAngle * Input.GetAxis("Horizontal");
        wheels[1].steerAngle = maxAngle * Input.GetAxis("Horizontal");

    }

}

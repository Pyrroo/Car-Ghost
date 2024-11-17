using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private static Transform targetTransform;
    public float cameraFollowSpeed; // чем меньше, тем быстрее камера
    private Vector3 cameraFollowVelocity = Vector3.zero;


    public void FollowTarget()
    {   
        if(targetTransform != null)
        {
             Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.transform.position, ref cameraFollowVelocity, cameraFollowSpeed);

            Quaternion targetRotation = Quaternion.Slerp
            (transform.rotation, targetTransform.rotation, cameraFollowSpeed);

            transform.rotation = targetRotation;
            transform.position = targetPosition; 
        }
   
    }
    private void FixedUpdate()
    {
        FollowTarget();
    }

    public static void DefinitionTarget()
    {
        targetTransform = GameObject.FindWithTag("Spawner").transform;
    }


}

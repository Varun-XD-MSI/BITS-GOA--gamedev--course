// using UnityEngine;

// public class CameraFollow : MonoBehaviour
// {
//     public Transform target;       // The object to follow
//     public float smoothSpeed = 0.125f;  // How smooth the camera follows
//     public Vector3 offset;         // Distance between camera and target

//     void LateUpdate()     // late update is initiated after update
//     {
//         Vector3 desiredPosition = target.position + offset;
//         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//         transform.position = smoothedPosition;
//     }
// }


// alternate way

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cartransform;
    public Transform cameratransform;
    void LateUpdate()
    {
        transform.position = new Vector3(cartransform.position.x, cartransform.position.y, -10f);
    }

   

}

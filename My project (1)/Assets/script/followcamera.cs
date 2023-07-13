using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraFollowSpeed = 5f;


    private Vector3 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
        offsetVector = CalculateOffSet(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTheCamera();
    }
    private void MoveTheCamera()
    {
        Vector3 targetToMove = target.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
   private Vector3 CalculateOffSet(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }

}

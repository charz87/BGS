using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private Transform target;

    private Vector3 cameraOffset;
    private Vector3 goalPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraOffset = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        goalPosition = target.position - cameraOffset;

        Vector3 goalDirection = (goalPosition - transform.position);
        Vector3 goalOffset = goalDirection * cameraSpeed * Time.fixedDeltaTime;

        if (Vector3.Dot((goalPosition - transform.position), goalPosition - (transform.position + goalOffset)) > 0.0f)
        {
            transform.position += goalOffset;
        }
        else
        {
            transform.position = goalPosition;
        }
    }

}

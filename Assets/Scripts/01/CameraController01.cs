using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController01 : MonoBehaviour
{
    public float zoomSpeed = 5;

    private Vector3 offset;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = playerTransform.position + offset;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Camera.main.fieldOfView += scroll * zoomSpeed;

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 50, 70);
    }

}

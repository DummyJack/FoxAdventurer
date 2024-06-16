using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController03 : MonoBehaviour
{
    public vThirdPersonCamera _vThirdPersonCamera;
    private readonly float MAX_DISTANCE = 4;
    private readonly float MIN_DISTANCE = 2;
    [SerializeField] private GameObject DialogueUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _vThirdPersonCamera.lockCamera = false;

        if (DialogueUI.activeInHierarchy)
        {
            _vThirdPersonCamera.lockCamera = true;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // print(scroll);

        if (scroll > 0) // 滾輪向上
        {
            _vThirdPersonCamera.defaultDistance += 1;


        }
        else if (scroll < 0) // 滾輪向下
        {
            _vThirdPersonCamera.defaultDistance -= 1;

        }
        _vThirdPersonCamera.defaultDistance = Mathf.Clamp(_vThirdPersonCamera.defaultDistance, MIN_DISTANCE, MAX_DISTANCE);
    }
}

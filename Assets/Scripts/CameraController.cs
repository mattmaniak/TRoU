using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraHolder;
    public float cameraSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        var mousePositionOnScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        var screenSize = new Vector3(Screen.width, Screen.height, 0.0f);
        var relativeMousePosition = new Vector3(mousePositionOnScreen.x / screenSize.x,
                                                mousePositionOnScreen.y / screenSize.y,
                                                0.0f);

        if (relativeMousePosition.x < 0.25f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.left)
                                               * Time.deltaTime * cameraSpeed;
        }
        else if (relativeMousePosition.x > 0.75f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.right)
                                               * Time.deltaTime * cameraSpeed;
        }

        if (relativeMousePosition.y < 0.25f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.down)
                                               * Time.deltaTime * cameraSpeed;
        }
        else if (relativeMousePosition.y > 0.75f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.up)
                                               * Time.deltaTime * cameraSpeed;
        }
        Debug.Log(cameraHolder.transform.position);
    }
}

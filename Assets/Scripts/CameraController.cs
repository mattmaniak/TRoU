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
        const float sqrtOfTwo = 1.4142f;

        bool movingDiagonally = false;
        float frameMultiplier = Time.deltaTime * cameraSpeed;

        var mousePositionOnScreen = new Vector3(Input.mousePosition.x,
                                                Input.mousePosition.y,
                                                0.0f);

        var screenSize = new Vector3(Screen.width, Screen.height, 0.0f);

        var relativeMousePosition = new Vector3(mousePositionOnScreen.x / screenSize.x,
                                                mousePositionOnScreen.y / screenSize.y,
                                                0.0f);

        // Normalize diagonal movement.
        if (((relativeMousePosition.x < 0.25f) || (relativeMousePosition.x > 0.75f))
            && ((relativeMousePosition.y < 0.25f) || (relativeMousePosition.y > 0.75f)))
        {
            frameMultiplier /= sqrtOfTwo;            
        }

        if (relativeMousePosition.x < 0.25f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.left)
                                               * frameMultiplier;
        }
        else if (relativeMousePosition.x > 0.75f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.right)
                                               * frameMultiplier;
        }

        if (relativeMousePosition.y < 0.25f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.down)
                                               * frameMultiplier;
        }
        else if (relativeMousePosition.y > 0.75f)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.up)
                                               * frameMultiplier;
        }
    }
}

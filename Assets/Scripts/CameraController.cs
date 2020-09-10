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
        RaycastHit objectHit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                                out objectHit, 100.0f)
                && (objectHit.transform.gameObject.name
                    == Player.Selector.playerSelectorName))
            {
                if (Player.Selector.Selected)
                {
                    Player.Selector.Unselect();
                    Debug.Log(objectHit.transform.gameObject.name + " unselected.");
                }
                else
                {
                    Player.Selector.Select();
                    Debug.Log(objectHit.transform.gameObject.name + " selected.");
                }
            }
        }
        MoveCamera();
    }

    void MoveCamera()
    {
        const float sqrtOfTwo = 1.4142f;
        const float minBorder = 0.01f;
        const float maxBorder = 0.99f;

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
        if (((relativeMousePosition.x < minBorder) || (relativeMousePosition.x > maxBorder))
            && ((relativeMousePosition.y < minBorder) || (relativeMousePosition.y > maxBorder)))
        {
            frameMultiplier /= sqrtOfTwo;            
        }

        if (relativeMousePosition.x < minBorder)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.left)
                                               * frameMultiplier;
        }
        else if (relativeMousePosition.x > maxBorder)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.right)
                                               * frameMultiplier;
        }

        if (relativeMousePosition.y < minBorder)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.down)
                                               * frameMultiplier;
        }
        else if (relativeMousePosition.y > maxBorder)
        {
            cameraHolder.transform.position += transform.TransformDirection(Vector3.up)
                                               * frameMultiplier;
        }
    }
}

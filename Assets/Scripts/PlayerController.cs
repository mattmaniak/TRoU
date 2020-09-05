using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpHeight = 1.0f;
    public float mouseSensitivity = 1.7f;
    public Transform camera;

    private bool _falling = false;
    private bool _jumping = false;
    
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        ControlByKeyboard();
        SimpleJump();
    }

    private void ControlByKeyboard()
    {
        float speed = walkSpeed;

        if (!_jumping && !_falling)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            if (Input.GetKey("w"))
            {
                transform.position += transform.TransformDirection(Vector3.forward)
                                    * Time.deltaTime * speed;
            }
            else if (Input.GetKey("s"))
            {
                transform.position += transform.TransformDirection(Vector3.back)
                                    * Time.deltaTime * speed;
            }
            
            if (Input.GetKey("a"))
            {
                transform.position += transform.TransformDirection(Vector3.left)
                                    * Time.deltaTime * speed;
            }
            else if (Input.GetKey("d"))
            {
                transform.position += transform.TransformDirection(Vector3.right)
                                    * Time.deltaTime * speed;
            }
            if (Input.GetKey("space"))
            {
                _jumping = true;
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void SimpleJump()
    {
        if (_jumping)
        {
            if (transform.position.y < jumpHeight)
            {
                transform.position += transform.TransformDirection(Vector3.up)
                                      * Time.deltaTime * jumpHeight;
            }
            else
            {
                _jumping = false;
                _falling = !_jumping;
            }
        }
        else if (_falling)
        {
            transform.position += transform.TransformDirection(Vector3.down)
                                  * Time.deltaTime * jumpHeight;
            if (transform.position.y <= 0.0f)
            {
                _jumping = _falling = false;
            }
        }
    }

    private void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        Vector3 currentRotation = new Vector3(0.0f, 0.0f, 0.0f);

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0.0f);
        camera.Rotate(-verticalRotation * mouseSensitivity, 0.0f, 0.0f);

        currentRotation = camera.localEulerAngles;
        if (currentRotation.x > 180.0f)
        {
            currentRotation.x -= 360.0f;
        }
        camera.localRotation = Quaternion.Euler(currentRotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float maxSpeed = 5;
    private Vector3 _velocity;
    private CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward)
                                  * Time.deltaTime * maxSpeed;
        }
        // Vector3 movementRatio = new Vector3(Input.GetAxis("Horizontal"), 0,
        //                                     Input.GetAxis("Vertical"));

        // _controller.Move(movementRatio * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpHeight = 1.0f;
    public static bool _selected = false;
    NavMeshAgent playerMeshAgent;

    bool _falling = false;
    bool _jumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMouseClick();
    }

    public static void Select()
    {
        _selected = true;
    }

    public static void Unselect()
    {
        _selected = false;
    }

    void MoveToMouseClick()
    {
        RaycastHit destinationHit;
        
        if (_selected && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                                out destinationHit, 10.0f))
            {
                playerMeshAgent.destination = destinationHit.point;
            }
        }
    }
}

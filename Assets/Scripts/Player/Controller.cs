﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        public float walkSpeed = 1.5f;
        public float runSpeed = 2.5f;
        public float jumpHeight = 1.0f;
        
        NavMeshAgent _playerMeshAgent;
        bool _falling = false;
        bool _jumping = false;
        
        // Start is called before the first frame update
        void Start()
        {
            _playerMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            MoveToMouseClick();
        }

        void MoveToMouseClick()
        {
            RaycastHit destinationHit;
            
            if (Selector.Selected && Input.GetMouseButtonDown(0)
                && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                                out destinationHit, 10.0f)
                && (destinationHit.transform.gameObject.name
                    != Selector.playerSelectorName))
            {
                _playerMeshAgent.destination = destinationHit.point;
            }
        }
    }
}
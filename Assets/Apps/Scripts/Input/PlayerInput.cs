using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behaviours;

namespace CustomInput {
    public class PlayerInput : MonoBehaviour {
        /// <summary>
        /// reference untuk class movement
        /// </summary>
        private Movement movement;
        /// <summary>
        /// reference untuk class interact
        /// </summary>
        private Interact interact;

        private void Awake() {
            movement = GetComponent<Movement>();
            interact = GetComponentInChildren<Interact>();
        }

        private void Update() {
            InputHandler();
        }

        /// <summary>
        /// untuk menghandle semua input dari user
        /// </summary>
        private void InputHandler() {
            movement.SetXDirection(Input.GetAxisRaw("Horizontal"));

            if (Input.GetKeyDown(KeyCode.E)) {
                interact.Execute();
            }
        }
    } 
}

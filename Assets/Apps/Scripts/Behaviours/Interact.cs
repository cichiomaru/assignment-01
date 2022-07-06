using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;
using CustomInput;

namespace Behaviours {
    public class Interact : MonoBehaviour, IInputReciever {
        /// <summary>
        /// reference untuk komponent interactible
        /// </summary>
        private Interactible _interactible;

        private void Start() {
            
        }

        /// <summary>
        /// menjalankan interaksi
        /// </summary>
        internal void Execute() {
            _interactible.Execute(transform);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            _interactible = GetInteractible(collision);

            if (_interactible != null) {
                _interactible.ShowInteractCanvas();
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            _interactible = GetInteractible(collision);

            if (_interactible != null) {
                _interactible.HideInteractCanvas();
            }
        }

        /// <summary>
        /// cek apakah object yang masuk dalam trigger adalah interactible
        /// </summary>
        /// <param name="collision"></param>
        /// <returns></returns>
        private Interactible GetInteractible(Collider2D collision) {
            return collision.gameObject.GetComponent<Interactible>();
        }

        public void AxisChanged(float value) {

        }

        public void ButtonPressed(string buttonName) {

        }
    }
}
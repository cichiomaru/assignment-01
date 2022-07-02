using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Behaviours;
using System;
using UI;

namespace CustomEvents {
    public class Interactible : MonoBehaviour {
        /// <summary>
        /// reference untuk komponent interact UI
        /// </summary>
        [SerializeField] private InteractUI interactUI;
        /// <summary>
        /// object dapat diinteraksikan
        /// </summary>
        public bool isInteractible;
        /// <summary>
        /// tag target untuk dideteksi
        /// </summary>
        [SerializeField] private string targetTag;
        /// <summary>
        /// untuk menampung function yang ingin dijalankan
        /// </summary>
        //[SerializeField] private UnityEvent onInteract;
        [SerializeField] private UnityEvent<Transform> onInteractWithTransform;

        private void Update() {
            if (isInteractible) {
                interactUI.ShowEnabled();
            }
            else {
                interactUI.ShowDisabled();
            }
        }

        internal void ShowInteractCanvas() {
            interactUI.Show();
        }

        internal void HideInteractCanvas() {
            interactUI.Hide();
        }

        /// <summary>
        /// menjalankan fungsi pada event onInteract
        /// </summary>
        public void Execute(Transform transform) {
            //onInteract.Invoke();
            if (isInteractible) {
                isInteractible = false;
                onInteractWithTransform.Invoke(transform);

            }
        }
    } 
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;

namespace Behaviours {
    public class Knockback : MonoBehaviour {
        /// <summary>
        /// knockback distance
        /// </summary>
        [SerializeField] private float distance;
        private float currentDistance;
        /// <summary>
        /// reference komponen movement
        /// </summary>
        private Movement movement;
        /// <summary>
        /// reference untuk komponen interactible
        /// </summary>
        private Interactible interactible;

        private void Awake() {
            movement = GetComponent<Movement>();
            interactible = GetComponent<Interactible>();
        }

        /// <summary>
        /// menjalankan fungsi knockback
        /// </summary>
        public void Execute(Transform _transform) {
            currentDistance = 0;

            StartCoroutine(Knock(_transform));
        }

        private IEnumerator Knock(Transform _transform) {
            movement.SetXDirection(GetDirection(_transform));

            while (currentDistance < distance) {
                currentDistance += movement.Offset().magnitude;
                yield return null;
            }

            movement.Stop();
            interactible.isInteractible = true;
        }

        /// <summary>
        /// mendapatkan arah knockback kiri atau kanan
        /// </summary>
        /// <param name="_transform"></param>
        /// <returns></returns>
        private float GetDirection(Transform _transform) {
            if (transform.position.x < _transform.position.x) {
                return -1;
            }
            return 1;
        }
    } 
}

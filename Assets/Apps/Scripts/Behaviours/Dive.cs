using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;

namespace Behaviours {
    public class Dive : MonoBehaviour {
        /// <summary>
        /// reference untuk komponen interactible
        /// </summary>
        private Interactible interactible;
        /// <summary>
        /// delay menunggu saat sudah dive
        /// </summary>
        [SerializeField] private float delay;
        /// <summary>
        /// kedalaman dive
        /// </summary>
        [SerializeField] private float depth;
        /// <summary>
        /// reference untuk komponent movement
        /// </summary>
        private Movement movement;

        private void Awake() {
            movement = GetComponent<Movement>();
            interactible = GetComponent<Interactible>();
        }

        public void Execute() {
            StartCoroutine(DiveAction());
        }
        private IEnumerator DiveAction() {
            float distance = 0;
            float yOrigin = transform.position.y;

            movement.SetYDirection(-1f);

            while (distance < depth) {
                distance += Mathf.Abs(movement.Offset().y);

                yield return null;
            }

            movement.SetYDirection(0);
            yield return new WaitForSeconds(delay);

            movement.SetYDirection(1);
            while (transform.position.y < yOrigin) {
                yield return null;
            }

            movement.SetYDirection(0);
            yield return new WaitForSeconds(.5f);

            interactible.isInteractible = true;
        }
    } 
}

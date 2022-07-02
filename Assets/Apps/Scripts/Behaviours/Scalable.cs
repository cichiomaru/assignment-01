using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;

namespace Behaviours {
    public class Scalable : MonoBehaviour {
        /// <summary>
        /// reference untuk komponent interactible
        /// </summary>
        private Interactible interactible;
        /// <summary>
        /// durasi scaling object
        /// </summary>
        [SerializeField] private float duration;
        /// <summary>
        /// target scale object
        /// </summary>
        [SerializeField] private float scaleTarget;

        private Vector3 originScale;
        private bool isBig;

        private void Awake() {
            interactible = GetComponent<Interactible>();
        }

        private void Start() {
            originScale = transform.localScale;
            isBig = false;
        }

        public void Execute() {
            if (isBig) {
                StartCoroutine(ScaleDown());
                isBig = false;
            } else {
                StartCoroutine(ScaleUp());
                isBig = true;
            }
        }

        private IEnumerator ScaleUp() {
            while (transform.localScale.x < scaleTarget) {
                transform.localScale += (Vector3.one * Time.deltaTime / duration);
                yield return null;
            }

            interactible.isInteractible = true;
        }

        private IEnumerator ScaleDown() {
            while (transform.localScale.x > originScale.x) {
                transform.localScale -= (Vector3.one * Time.deltaTime / duration);
                yield return null;
            }

            interactible.isInteractible = true;
        }
    } 
}

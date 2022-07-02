using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;

namespace Behaviours {
    public class Fading : MonoBehaviour {
        /// <summary>
        /// waktu untuk hilang
        /// </summary>
        [SerializeField] private float timer;
        /// <summary>
        /// reference untuk object text bubble
        /// </summary>
        [SerializeField] Canvas canvas;
        /// <summary>
        /// reference untuk komponen interactible
        /// </summary>
        private Interactible interactible;

        private void Awake() {
            interactible = GetComponent<Interactible>();
        }

        public void Execute(Transform _transform) {
            StartCoroutine(Fade());
        }

        /// <summary>
        /// menghilangkan object setelah x second
        /// </summary>
        /// <returns></returns>
        private IEnumerator Fade() {
            canvas.gameObject.SetActive(true);

            yield return new WaitForSeconds(timer);
            canvas.gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            interactible.isInteractible = true;
        }
    } 
}

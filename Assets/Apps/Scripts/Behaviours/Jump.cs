using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;

namespace Behaviours {
    public class Jump : MonoBehaviour {
        private Interactible interactible;
        /// <summary>
        /// reference ke movement komponent
        /// </summary>
        private Movement movement;
        /// <summary>
        /// ketinggian lompatan
        /// </summary>
        [SerializeField] private float height;
        /// <summary>
        /// delay untuk mendarat
        /// </summary>
        [SerializeField] private float delay;

        private void Awake() {
            movement = GetComponent<Movement>();
            interactible = GetComponent<Interactible>();
        }
        public void Execute() {
            StartCoroutine(JumpAction());
        }

        private IEnumerator JumpAction() {
            float distance = 0;
            float yOrigin = transform.position.y;

            movement.SetYDirection(1);
            while (distance < height) {
                distance += movement.Offset().y;
                yield return null;
            }

            movement.SetYDirection(0);
            yield return new WaitForSeconds(delay);

            movement.SetYDirection(-1);
            while (transform.position.y > yOrigin) {
                yield return null;
            }

            movement.SetYDirection(0);
            yield return new WaitForSeconds(0.5f);
            interactible.isInteractible = true;
        }
    } 
}

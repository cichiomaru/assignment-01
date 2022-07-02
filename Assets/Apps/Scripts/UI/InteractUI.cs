using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {
    public class InteractUI : MonoBehaviour {
        [SerializeField] private GameObject interactEnabled;
        [SerializeField] private GameObject interactDisabled;

        internal void ShowEnabled() {
            interactEnabled.gameObject.SetActive(true);
            interactDisabled.gameObject.SetActive(false);
        }

        internal void ShowDisabled() {
            interactEnabled.gameObject.SetActive(false);
            interactDisabled.gameObject.SetActive(true);
        }

        internal void Show() {
            gameObject.SetActive(true);
        }

        internal void Hide() {
            gameObject.SetActive(false);
        }
    } 
}

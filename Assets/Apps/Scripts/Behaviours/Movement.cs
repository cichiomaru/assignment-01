using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours {
    public class Movement : MonoBehaviour {
        /// <summary>
        /// arah pergerakan
        /// </summary>
        private Vector3 direction;
        /// <summary>
        /// mengijinkan entity untuk bergerak
        /// </summary>
        public bool isAbleToMove;

        /// <summary>
        /// kecepatan pergerakan entity
        /// </summary>
        [SerializeField] private float speed;

        private void Start() {
            direction = new Vector3();
        }

        private void Update() {
            if (isAbleToMove)
                PositionUpdate();
        }

        /// <summary>
        /// update posisi entity berdasarkan nilai direction
        /// </summary>
        private void PositionUpdate() {
            transform.position += Offset();
        }

        /// <summary>
        /// perpindahan object
        /// </summary>
        /// <returns></returns>
        public Vector3 Offset() {
            return direction * speed * Time.deltaTime;
        }

        /// <summary>
        /// stop pergerakan
        /// </summary>
        internal void Stop() {
            direction = Vector3.zero;
        }

        /// <summary>
        /// set arah pergerakan entity di sumbu X
        /// </summary>
        /// <param name="_direction">arah pergerakan entity</param>
        internal void SetXDirection(float _x) {
            direction.x = _x;
        }
        /// <summary>
        /// set arah pergerakan di sumbu y
        /// </summary>
        /// <param name="_y"></param>
        internal void SetYDirection(float _y) {
            direction.y = _y;
        }
    }
}
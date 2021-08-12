using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class PlayerMove : MonoBehaviour {
        public float acceleration;
        public Rigidbody2D rigidbody;
        public float friction;
        private Vector3 dir;
        private float angle;
        private float angleX;
        private float angleY;
        private bool isAccX;
        private bool isAccY;
        private Vector3 mousePosXY;
        private Vector3 lookTarget;
        private float signedAcceleration;
        private Vector2 momentum;
        private Vector2 vel;

        public float mouseFollowLerp = 5.0f;

        private void Start() {
            acceleration = 1.0f;
            rigidbody = GetComponent<Rigidbody2D>();
            friction = 0.1f;
        }

        private void Update() {
            mousePosXY = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosXY.z = 0;
            dir = (mousePosXY - transform.position).normalized;

            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            lookTarget = new Vector3(0, 0, angle);

            if (transform.eulerAngles.z > 180 && transform.eulerAngles.z - angle > 180)
            {
                lookTarget.z += 360;
            }
            else if (transform.eulerAngles.z < 180 && angle - transform.eulerAngles.z > 180)
            {
                lookTarget.z -= 360;
            }

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, lookTarget, mouseFollowLerp);

            isAccX = false;
            isAccY = false;
            if (Input.GetKey(KeyCode.W)) {
                angleY = (transform.eulerAngles.z+90) * Mathf.Deg2Rad;
                isAccY = true;
            }
            else if (Input.GetKey(KeyCode.A)) {
                angleX = (transform.eulerAngles.z+180) * Mathf.Deg2Rad;
                isAccX = true;
            }
            else if (Input.GetKey(KeyCode.D)) {
                angleX = (transform.eulerAngles.z) * Mathf.Deg2Rad;
                isAccX = true;
            }
            else if (Input.GetKey(KeyCode.S)) {
                angleY = (transform.eulerAngles.z-90) * Mathf.Deg2Rad;
                isAccY = true;
            }

            if (isAccX && isAccY) {
                if (angleX - angleY > 180)
                {
                    angleY += 360;
                }
                else if (angleY - angleX > 180)
                {
                    angleX += 360;
                }

                angle = (angleX + angleY) / 2;
            }
            else if (isAccX) {
                angle = angleX;
            }
            else if (isAccY) {
                angle = angleY;
            }

            if (isAccX || isAccY) {
                vel.x = Mathf.Cos(angle);
                vel.y = Mathf.Sin(angle);
                vel *= acceleration;
                Debug.Log(angle);
                Debug.Log(vel);
                rigidbody.AddForce(vel);
            }
        }
    }
}
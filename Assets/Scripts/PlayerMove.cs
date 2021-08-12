using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class PlayerMove : MonoBehaviour {
        public float acceleration = 1.0f;
        public float turnRate = 1.0f;
        public float friction = 0.1f;
        public Rigidbody2D rbody;
        private Vector2 properVelocity;
        private Vector2 momentum;
        private float effectiveMass;

        public float mouseFollowLerp = 5.0f;

        private void Start() {
            rbody = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            Relativity.SetTimeDistScales(rbody.velocity);
            Relativity.SetRedshift(rbody.velocity);
            UpdateMovement();
            UpdateRotation();
        }

        private void UpdateMovement() {
            float angle = 0;
            if (Input.GetKey(KeyCode.W)) {
                angle = (transform.eulerAngles.z+90) * Mathf.Deg2Rad;
            }
            else if (Input.GetKey(KeyCode.S)) {
                angle = (transform.eulerAngles.z-90) * Mathf.Deg2Rad;
            }

            momentum = Relativity.MomentumFromVelocity(rbody.mass, rbody.velocity);

            if (angle != 0 && rbody.velocity.magnitude < Relativity.speedOfLight) {
                Vector2 acc;
                acc.x = Mathf.Cos(angle);
                acc.y = Mathf.Sin(angle);
                acc *= acceleration;
                momentum += acc*Time.deltaTime;
            }

            momentum *= (1 - friction*Time.deltaTime);
            rbody.velocity = Relativity.VelocityFromMomentum(rbody.mass, momentum);
            Debug.Log(Relativity.gamma);
        }

        private void UpdateRotation() {
            // not relativistic. (yet...?)

            float angle = 0;
            if (Input.GetKey(KeyCode.A)) {
                angle = turnRate;
            }
            else if (Input.GetKey(KeyCode.D)) {
                angle = -turnRate;
            }

            Vector3 torque = new Vector3(0, 0, angle);
            
            rbody.AddTorque(angle);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class Relativity : MonoBehaviour {
        public static float speedOfLight = 5.0f;
        public static float XScale = 1.0f;
        public static float YScale = 1.0f;
        public static float gamma = 1.0f;
        public static float scale = 1.0f;
        public static Vector2 scaleDir = new Vector2(1, 0);

        public static void SetTimeDistScales(Vector2 velocity) {
            if (velocity.x == 0 && velocity.y == 0) {
                gamma = 1.0f;
                XScale = 1.0f;
                YScale = 1.0f;
                Time.timeScale = 1.0f;
            }
            else {
                gamma = 1.0f / Mathf.Sqrt(1.0f - Mathf.Pow(velocity.magnitude / Relativity.speedOfLight, 2));
                scaleDir = velocity.normalized;
                scale = 1 / gamma;
                Time.timeScale = 1.0f;
                Debug.Log(scale);
                //Time.fixedDeltaTime = 1.0f;
            }
        }

        public static void SetRedshift(Vector2 velocity) {

        }

        public static Vector2 MomentumFromVelocity(float mass, Vector2 velocity) {
            return gamma * mass * velocity;
        }

        public static Vector2 VelocityFromMomentum(float mass, Vector2 momentum) {
            return momentum / (mass * gamma);
        }
    }
}
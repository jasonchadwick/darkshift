using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class Relativity : MonoBehaviour {
        public static float speedOfLight = 5.0f;
        public static float XScale = 1.0f;
        public static float YScale = 1.0f;
        public static float gamma = 1.0f;

        public static void SetTimeDistScales(Vector2 velocity) {
            gamma = 1.0f / Mathf.Sqrt(1.0f - Mathf.Pow(velocity.magnitude / Relativity.speedOfLight, 2));
            XScale =  Mathf.Sqrt(1.0f - Mathf.Pow(velocity.x / Relativity.speedOfLight, 2));
            YScale =  Mathf.Sqrt(1.0f - Mathf.Pow(velocity.y / Relativity.speedOfLight, 2));
            Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = 1.0f;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class GlobalScale : MonoBehaviour {
        public float scaleLerp = 10.0f;
        private void Update() {
            Transform[] childArray = GetComponentsInChildren<Transform>(true);
    
            //List<Transform> endChildrenArray = new List<Transform>();
            //foreach(Transform child in childArray)
            //{
            //    if(child.childCount == 0)
            //        endChildrenArray.Add(child);
            //}

            float phi = Vector2.Angle(Vector2.right, Relativity.scaleDir);

            // todo: save initial scales.
            // todo: rotate/scale positions as well as scales. (relative to player?)

            //foreach(Transform child in childArray) {
            //    child.eulerAngles = Vector3.Lerp(child.eulerAngles, new Vector3(0, 0, phi), scaleLerp);
            //    child.localScale = Vector3.Lerp(child.localScale, new Vector3(Relativity.scale, 1, 1), scaleLerp);
            //}

            float deltaPhi = phi - transform.eulerAngles.z;
            if (deltaPhi > 180) {
                deltaPhi -= 180;
            }
            else if (deltaPhi < -180) {
                deltaPhi += 180;
            }

            transform.position = Quaternion.Euler(0, 0, deltaPhi)*transform.position;
            transform.eulerAngles = new Vector3(0, 0, phi);
            transform.localScale = new Vector3(Relativity.scale, 1, 1);
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, phi), scaleLerp);
            //transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Relativity.scale, 1, 1), scaleLerp);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets {
    public class GlobalScale : MonoBehaviour {
        private void Update() {
            Vector3 newScale = new Vector3(Relativity.XScale, Relativity.YScale, 1.0f);
            transform.localScale = newScale;
        }
    }
}
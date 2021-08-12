using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    //let camera follow target
    public class LightFacePlayerDir : MonoBehaviour
    {
        public Transform target;

        private void Start()
        {
            if (target == null) return;
        }

        private void Update()
        {
            transform.position = target.position;
            transform.eulerAngles = target.eulerAngles;
        }

    }
}

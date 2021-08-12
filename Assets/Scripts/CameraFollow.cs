using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float sizeLerpVal = 1.0f;
        public float followLerpVal = 1.0f;
        public float minSize = 5.0f;
        public float maxSize = 10.0f;
        private Vector3 targetXYvec;

        private void Start()
        {
            if (target == null) return;

            Camera.main.orthographicSize = minSize;
        }

        private void Update()
        {
            // TODO: focus on point a bit in front of player
            targetXYvec = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetXYvec, followLerpVal*Time.deltaTime);

            // camera view size
            float targetSize = minSize + (maxSize-minSize) * target.GetComponent<Rigidbody2D>().velocity.magnitude / Relativity.speedOfLight;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, sizeLerpVal*Time.deltaTime);

            // camera rotation follow player direction
            Vector3 targetAngles = target.eulerAngles;
            if (transform.eulerAngles.z - targetAngles.z > 180) {
                targetAngles.z += 360;
            }
            else if (targetAngles.z - transform.eulerAngles.z > 180) {
                targetAngles.z -= 360;
            }
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, followLerpVal*Time.deltaTime);
        }

    }
}

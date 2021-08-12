using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    //let camera follow target
    public class LightFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 1.0f;
        public float lightLerp = 10.0f;
        float alpha;

        private Vector3 offset;

        private Vector3 targetPos;

        private Animator animator;

        Vector2 dir = Vector2.zero;

        private void Start()
        {
            if (target == null) return;
            animator = GetComponent<Animator>();
            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) return;

            //targetPos = target.position + offset;
            transform.position = target.position;
            //transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                alpha = 90;
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                alpha = 270;
                dir.x = 1;
            }
            else
            {
                dir.x = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                if (dir.x != 0)
                {
                    if (alpha == 270)
                    {
                        alpha = 270+45;
                    }
                    else
                    {
                        alpha = 45;
                    }
                    
                }
                else {
                    alpha = 0;
                }
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (dir.x != 0)
                {
                    alpha = (alpha + 180) / 2;
                }
                else {
                    alpha = 180;
                }
                dir.y = -1;
            }
            else
            {
                dir.y = 0;
            }
                        
            Vector3 euler = new Vector3(0, 0, alpha);
            Debug.Log(transform.eulerAngles);
            Vector3 targete = euler;
            if (transform.eulerAngles.z > 180 && transform.eulerAngles.z - alpha > 180)
            {
                targete.z += 360;
            }
            else if (transform.eulerAngles.z < 180 && alpha - transform.eulerAngles.z > 180)
            {
                targete.z -= 360;
            }
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targete, lightLerp * Time.deltaTime);
            //transform.eulerAngles = euler;
            //transform.rotation = rot;
        }

    }
}

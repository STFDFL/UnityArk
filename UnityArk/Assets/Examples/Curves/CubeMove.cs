using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Examples.Curves
{
    public class CubeMove : MonoBehaviour
    {
        public AnimationCurve animationCurve;
        public float speed;
        public Vector3 finalPosition;


        private void Update()
        {
            animationCurve.postWrapMode = WrapMode.ClampForever;
            transform.Translate(Vector3.forward * animationCurve.Evaluate(Time.time) * speed);
        }

    }
}

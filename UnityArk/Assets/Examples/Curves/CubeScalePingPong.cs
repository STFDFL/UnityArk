using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Examples.Curves
{
    public class CubeScalePingPong : MonoBehaviour
    {
        public AnimationCurve animationCurve;

        private Vector3 initialScale;
        private Vector3 finalScale;
        private float graphValue;

        private void Awake()
        {
            initialScale = transform.localScale;
            finalScale = Vector3.one;
            animationCurve.postWrapMode = WrapMode.PingPong;
        }

        private void Update()
        {
            graphValue = animationCurve.Evaluate(Time.time);
            transform.localScale = finalScale * graphValue;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ark.Examples.ExplosiveBarrels
{


    public class ExplosiveBarrelManager : MonoBehaviour
    {
        public static List<ExplosiveBarrel> AllTheBarrels = new List<ExplosiveBarrel>();

        private void OnDrawGizmos()
        {
            foreach (var barrel in AllTheBarrels)
            {
                //Gizmos.DrawLine(transform.position, barrel.transform.position);

                Vector3 managerPos = transform.position;
                Vector3 barrelPos = barrel.transform.position;
                float halfHeight = (managerPos.y - barrelPos.y) * 0.5f;
                Vector3 offset = Vector3.up * halfHeight;

                Handles.DrawBezier(
                    managerPos,
                    barrelPos,
                    managerPos-offset,
                    barrelPos+offset,
                    Color.white,
                    EditorGUIUtility.whiteTexture,
                    1f
                    );
            }

        }
    }

}

using UnityEngine;
using System.Collections;


namespace PhotonOfficialTutorial
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        private Animator animator;



        #region MonoBehaviour Callbacks


        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }
        void Update()
        {
            if (!animator)
            {
                return;
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v = 0;
            }
            animator.SetFloat("Speed", h * h + v * v);
        }

        #endregion
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CutsceneToolkit
{

    public class CutsceneManager : MonoBehaviour
    {
        public Animator animator;
        [Tooltip("The name of the Trigger in the Animator that Play() should activate.")]
        public string trigger = "start";

        [Tooltip("If true, prevents player from moving and disables mobile controls.")]
        public bool removePlayerControl = true;

        [Tooltip("If true, the Camera's object to follow will be set to the Camera Target object. This can be animated and set to false at any time to set the Camera's object to follow back to the original (usually the player)")]
        public bool animateCamera = true;
        public GameObject cameraTarget;

        public GameObject cam;

        public FollowObject follow;

        public GameObject player;
        public Behaviour playerScript;
        // Mobile controls used to be disableable, this behaviour was removed due to issues it caused while players were holding controls when they were disabled, causing them to be stuck in the position they were in when reenabled. This is kept incase someone would want to fix it, which could be done by deselecting the mobile controls before diabling.
        //public GameObject mobileControls;
        //private bool mobileEnabled;

        public void Play()
        {
            animator.SetTrigger(trigger);
        }

        // Start is called before the first frame update
        void Start()
        {
            // Mobile controls used to be disableable, this behaviour was removed due to issues it caused while players were holding controls when they were disabled, causing them to be stuck in the position they were in when reenabled. This is kept incase someone would want to fix it, which could be done by deselecting the mobile controls before diabling.
            /*
                    if (mobileControls != null)
                    {
                        mobileEnabled = mobileControls.activeSelf;
                    }
                    else
                    {
                        mobileEnabled = false;
                    }
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (animateCamera)
            {
                if (follow == null)
                {
                    cam = Camera.main.gameObject;
                    follow = cam.transform.parent.GetComponent<FollowObject>();
                }

                follow.objectToFollow = cameraTarget;
            }
            else
            {

                if (follow == null)
                {
                    cam = Camera.main.gameObject;
                    follow = cam.transform.parent.GetComponent<FollowObject>();
                }
                follow.objectToFollow = player;
            }

            playerScript.enabled = !removePlayerControl;
            // Mobile controls used to be disabled, this behaviour was removed due to issues it caused while players were holding controls when it was disabled, causing it to be stuck in that position. when reenabled.
            /*
            if (mobileEnabled)
            {
                mobileControls.SetActive(!removePlayerControl);
            }*/
        }
    }

}
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            //Triggers StandUp Movement
            if(Input.GetButtonDown("Stand Up Action"))
            {
                mAnimator.SetTrigger("TriggerStandUp");
            }

            //Triggers Crouch Movement
            if(Input.GetButtonDown("Crouch Action"))
            {   
                mAnimator.SetTrigger("TriggerCrouch");
            }

            //Triggers Shoot Animation
            if(Input.GetButtonDown("ShootMouse"))
            {
                mAnimator.SetBool("isShooting", true);
            }

            //When we release the shoot button, it restes back to standing idle
            if(Input.GetButtonUp("ShootMouse"))
            {
                mAnimator.SetBool("isShooting", false);
            }

        }

    }


using UnityEngine;

public class AnimationManager : MonoBehaviour

{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            //Triggers StandUp Movement
            if(Input.GetButtonDown("Stand Up Action"))
            {
                animator.SetTrigger("TriggerStandUp");
            }

            //Triggers Crouch Movement
            if(Input.GetButtonDown("Crouch Action"))
            {   
                animator.SetTrigger("TriggerCrouch");
            }

            //Triggers Shoot Animation
            if(Input.GetButtonDown("ShootMouse"))
            {
                animator.SetBool("isShooting", true);
            }

            //When we release the shoot button, it restes back to standing idle
            if(Input.GetButtonUp("ShootMouse"))
            {
                animator.SetBool("isShooting", false);
            }

        }

    }


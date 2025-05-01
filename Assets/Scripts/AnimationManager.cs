using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            //Triggers StandUp Movement
            if(Input.GetButtonDown("Stand Up Action"))
            {
                playerAnimator.SetTrigger("TriggerStandUp");
            }

            //Triggers Crouch Movement
            if(Input.GetButtonDown("Crouch Action"))
        {
            playerAnimator.SetTrigger("TriggerCrouch");
        }

        if (Input.GetButtonDown("ShootMouse"))
        {
            playerAnimator.SetTrigger("isShooting");
        }

        }

    }


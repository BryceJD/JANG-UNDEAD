using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour

{
    private Animator animator;
    public bool reloading;
    public bool crouching;
    public AudioSource rechamber;
    [SerializeField] private Ammunition ammunition;

    void Start()
    {
        animator = GetComponent<Animator>();
        crouching = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading == true)
        {
            return;
        }
        //Triggers StandUp Movement
        if (Input.GetButtonDown("Stand Up Action"))
        {
            animator.SetTrigger("TriggerStandUp");
            //Set the crouching bool to false
            crouching = false;
        }

        //Triggers Crouch Movement
        if (Input.GetButtonDown("Crouch Action"))
        {
            animator.SetTrigger("TriggerCrouch");
            //Set the crouching bool to true
            crouching = true;
        }

        //Triggers Shoot Animation
        if (Input.GetButtonDown("ShootMouse") && crouching == false && reloading == false)
        {
            animator.SetTrigger("TriggerShoot");
            ammunition.ReduceByOne();
        }

        if (ammunition.IsEmpty())
        {
            animator.SetTrigger("TriggerCrouch");
            animator.ResetTrigger("Stand Up");

            reloading = true;
            crouching = true;

            StartCoroutine(Reload());
        }

    }

    //Coroutine which handles reloading - let's call this Reload
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        rechamber.Play();
        yield return new WaitForSeconds(2);

        reloading = false;

        ammunition.Reload();

    }
    

}


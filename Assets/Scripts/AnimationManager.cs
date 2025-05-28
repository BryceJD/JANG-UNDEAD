using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour

{
    private Animator animator;
    public bool reloading;
    public bool crouching;
    public AudioSource rechamber;
    [SerializeField] private Ammunition ammunition;
    private float timeSinceLastShot = 0f;
    public float fireRate = 0.5f; // Adjust as needed

    void Start()
    {
        animator = GetComponent<Animator>();
        crouching = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading) return;

        timeSinceLastShot += Time.deltaTime;

        // Stand up
        if (Input.GetButtonDown("Stand Up Action"))
        {
            animator.SetTrigger("TriggerStandUp");
            crouching = false;
        }

        // Crouch
        if (Input.GetButtonDown("Crouch Action"))
        {
            animator.SetTrigger("TriggerCrouch");
            crouching = true;
        }

        // SHOOT
        if (Input.GetButtonDown("ShootMouse") && !crouching && !reloading && timeSinceLastShot >= fireRate)
        {
            if (!ammunition.IsEmpty())
            {
                animator.SetTrigger("TriggerShoot");
                ammunition.ReduceByOne();
                timeSinceLastShot = 0f; // reset cooldown
            }
        }

        // Start Reload
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


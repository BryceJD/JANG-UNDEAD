using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator anim;
    public GameObject zombie;
    public bool Spawning;
    public float spawnAtTime;

    //Int variable to say which location we are occupying
    public int occupiedLocation;

    private ZombieSpawner spawner;
    private bool isStanding;

    public int damage = 2;
    private Health playerHealth;

    //We need some variables:
    //A min shoot delay
    public float minShootDelay = .5f;

    //A max shoot delay
    public float maxShootDelay = 2f;
    //A current shoot delay
    public float currentShootDelay = 0f;

    //A timer which keeps tracks of how much time has passed since the last shot
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        spawner = FindAnyObjectByType<ZombieSpawner>();

        //The current shoot delay should be a random number between the min and max shoot delay
        currentShootDelay = Random.Range(minShootDelay, maxShootDelay);

    }

    // Update is called once per frame
    void Update()
    {
        //Increase the shoot timer in seconds
        timer += Time.deltaTime;
        //If the shoot timer is greater than the current shoot delay
        if (timer >= currentShootDelay)
        {

            //Then we will tell the Animator to set the 'Shoot' trigger
            //Randomise the current shoot delay again
            anim.SetTrigger("Shoot");

            currentShootDelay = Random.Range(minShootDelay, maxShootDelay);

            //Reset the timer to zero
            timer = 0f;
        }        
    }

    public void SetStandingTrue()
    {
        isStanding = true;
    }

    public void SetStandingFalse()
    {
        isStanding = false;
    }

    //There is a built in Unity function called OnMouseDown which detects when an object has been clicked
    //The object needs to have a collider for this to work
    private void OnMouseDown()
    {
        if (!isStanding)
        {
            return;
        }

        //Check if the player is idling
        GameObject player = GameObject.FindWithTag("Player");
        // early return (only available in a void method) => stop doing anything
        if (player == null)
        {
            // do nothing and stop here
            return;
        }

        //Check if the player is crouching or reloading (by talking to the AnimationManager)
        //If they are, then return (stop running the code)
        AnimationManager animationManager = player.GetComponent<AnimationManager>();
        if (animationManager.crouching || animationManager.reloading)
        {
            return;
        }

        Die();
    }

    private void Die()
    {
        anim.Play("ZombieDeath");

        //Talk to the zombie spawner and tell it the location is no longer occupied
        spawner.locations[occupiedLocation].occupiedLocations = false;

        // TODO: 1) find score manager 2) increment score
        ScoreManager.instance.IncreaseScoreByOne();

        Destroy(transform.parent.gameObject, 0.5f);
    }

    // called during the shooting animation
    public void ShootPlayer()
    {
        //Check if the player is idling
        GameObject player = GameObject.FindWithTag("Player");
        // early return (only available in a void method) => stop doing anything
        if (player == null) 
        {
            // do nothing and stop here
            return; 
        }

        Animator playerAnimator = player.GetComponent<Animator>();
        AnimatorStateInfo currentStateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        bool playerIsInIdleState = currentStateInfo.IsName("Base Layer.JangIdle");
        // ! or != means "NOT" equal 
        if (!playerIsInIdleState)
        {
            //If they are not idling, we take damage
            Health health = player.GetComponent<Health>();
            health.TakeDamage(damage);
            
        }

    }

}

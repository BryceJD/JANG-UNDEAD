using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        spawner = FindAnyObjectByType<ZombieSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    //There is a built in Unity function called OnMouseDown which detects when an object has been clicked
    //The object needs to have a collider for this to work
    private void OnMouseDown()
    {
        anim.Play("ZombieDeath");

        //Talk to the zombie spawner and tell it the location is no longer occupied
        spawner.locations[occupiedLocation].occupiedLocations = false; 

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

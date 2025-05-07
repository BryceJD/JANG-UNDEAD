using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator anim;
    public GameObject zombie;
    public bool Spawning;
    public float spawnAtTime;
    
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
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
        Destroy(gameObject, 0.5f);
    }

}

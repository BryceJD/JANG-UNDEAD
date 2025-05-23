using UnityEngine;

public class ZombieGrunt : MonoBehaviour

{

    //A variable to hold an audiosource we want to play
    public AudioSource zombieGrunt;

    public void PlayGrunt()
    {
        //access our audio source variable and tell it to play
        zombieGrunt.Play();
    }



}

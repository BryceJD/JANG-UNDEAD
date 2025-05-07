using UnityEngine;

public class PlaySoundFromAnimation : MonoBehaviour

{

    //A variable to hold an audiosource we want to play
    public AudioSource source;
     
    public void PlaySound()
    {
        //access our audio source variable and tell it to play
        source.Play();
    }

}

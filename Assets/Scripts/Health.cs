using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

public int playerHealth;
public int maxPlayerHealth = 20;
public AudioSource hitSound;
public GameObject hitSprite;
public Slider healthBarSlider;

    private bool isHitRoutineRunning = false;
    private bool isDead = false;
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = maxPlayerHealth;
        hitSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.maxValue = maxPlayerHealth;
        healthBarSlider.value = playerHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) { return; }

        hitSound.Play();
        if (isHitRoutineRunning == false)
        {
            StartCoroutine(HitSequence());
        }

       

        playerHealth -= amount;
        if (playerHealth <=  0)
        {
           isDead = true;
           StartCoroutine(DeathSequence()); 
        }
    }

    private IEnumerator HitSequence()
    {
        isHitRoutineRunning = true;
        hitSprite.SetActive(true);
        {
            SpriteRenderer renderer = hitSprite.GetComponent<SpriteRenderer>();
            Color newColor = renderer.material.color;
            for (float f = 1f; f >= 0; f -= .2f)
            {
                newColor.a = f;
                renderer.material.color = newColor;
                yield return new WaitForSeconds(.09f);
            }

        }
            yield return new WaitForSeconds(0.5f);

        
        hitSprite.SetActive(false);
        isHitRoutineRunning = false;
    }
   
    //Coroutine
    private IEnumerator DeathSequence()
    {
        //Play the death animation
        GetComponent<Animator>().SetTrigger("Death");


        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("SampleScene");
    }

    //For player death sequence we need to make a coroutine to handle animation and game reset. 
    // 
}

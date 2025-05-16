using UnityEngine;

public class Health : MonoBehaviour
{

public int playerHealth;
public int maxPlayerHealth = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        if(playerHealth <=  0)
        {
            Destroy(gameObject);
        }
    }
}

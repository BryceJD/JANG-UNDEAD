using UnityEngine;

[System.Serializable]

//Custom data set which stores the poition and rotation the zombie should have
public struct ZombieLocation
{
    //Variable which stores the zombies position
    public Transform zombiePosition;
    //Variable which stores the zombies scale
    public Vector3 zombieScale;
}
public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float minRespawnTime;
    public float maxRespawnTime;

    //Variable for our current respawn time
    private float currentRespawnTime = 2f;
    //Variale for a timer, which will count up later
    private float timer;

    public ZombieLocation[] locations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Picking a random number between min and max respawn time
        currentRespawnTime = Random.Range(minRespawnTime, maxRespawnTime);
        //assign this to our current respawn time variable
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase our timer variable in seconds
        timer += Time.deltaTime;
        //When the timer is greater than the current spawn time
        if(timer > currentRespawnTime)
        {
            GameObject newZombie = Instantiate(zombie);

            //Pick a random zombie location from our array of zombie locations
            //To do this, we need to:
            //Pick a random number between 0 and the number of items we have in the locations array
            Random.Range(0, locations.Length);
            //Use this number to pick a location from our array of locations

            //Set the position of our new zombie to our location position

            //Set the scale of our new zombie to our location scale

            currentRespawnTime = Random.Range(minRespawnTime, maxRespawnTime);
            timer = 0;
        } 

    }
}

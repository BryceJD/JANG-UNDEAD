using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Custom data set which stores the poition and rotation the zombie should have
public class ZombieLocation
{
    //Variable which stores the zombies position
    public Transform zombiePosition;
    //Variable which stores the zombies scale
    public Vector3 zombieScale;

    //A bool which says if this location is occupied
    public bool occupiedLocations;
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

    //A list of available locations
    public List<ZombieLocation> availableLocationsList;

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
        if (timer > currentRespawnTime)
        {

            //Clear the availableLocationsList so we have a blank list
            availableLocationsList.Clear();
            //Check each location, and if it is not occupied, we add it to the available locations list
            foreach (ZombieLocation location in locations)
            {
                if (location.occupiedLocations == false)
                {
                    availableLocationsList.Add(location);
                }
            }

            //Hint: you will need to use a loop - either for or foreach

            //If the length of available locations list is greater than zero
            if (availableLocationsList.Count > 0)
            {
                GameObject newZombie = Instantiate(zombie);

                //Run the below code BUT instead of picking a random location from the locations array
                //We pick a random location from the availableLocations list

                //Pick a random zombie location from our array of zombie locations
                //To do this, we need to:
                //Pick a random number between 0 and the number of items we have in the locations array
                int locationIndex = Random.Range(0, availableLocationsList.Count);

                //We want to make the occupied bool true for this location
                availableLocationsList[locationIndex].occupiedLocations = true;

                Vector3 newPosition = availableLocationsList[locationIndex].zombiePosition.position;
                newPosition.z -= 1f;

                newZombie.transform.position = newPosition;

                newZombie.transform.localScale = availableLocationsList[locationIndex].zombieScale;
                //Set the position of our new zombie to our location position

                //Set the scale of our new zombie to our location scale

                //We get the Zombie component from the new Zombie
                //We access its occupied location int
                //We then use System.Array.IndexOf -
                //This allows us to specify an array, and specify an object (in this case, ZombieLocation)
                //And calculates the index that object has in the array
                //We use availableLocationsList[locationIndex] as the object because
                //This is the Zombie location we have chosen from the availableLocationsList
                ZombieLocation selectedLocation = availableLocationsList[locationIndex];
                int indexOfSelectedLocation = System.Array.IndexOf(locations, selectedLocation);

                newZombie.GetComponentInChildren<Zombie>().occupiedLocation = indexOfSelectedLocation;
            }
            currentRespawnTime = Random.Range(minRespawnTime, maxRespawnTime);
            timer = 0;


        }

    }
}

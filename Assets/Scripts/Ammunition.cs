using UnityEngine;


public class Ammunition : MonoBehaviour
{
    [SerializeField] private int maxBulletCount = 6;
    [SerializeField] private GameObject[] bulletIcons;

    [SerializeField] // serialized for debug purposes only
    private int bulletCount = 6;

    private void Start()
    {
        bulletCount = maxBulletCount;
    }

    public void ReduceByOne()
    {
        bulletCount--;
        UpdateDisplay();
    }

    public bool IsEmpty()
    {
        return bulletCount == 0;
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < bulletIcons.Length; i++)
        {
            bool shouldBeActive = i < bulletCount;
            bulletIcons[i].SetActive(shouldBeActive);
        }
    }

 

    public void Reload()
    {
        bulletCount = maxBulletCount;
        UpdateDisplay();
    }
}

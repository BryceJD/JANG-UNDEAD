using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    

    private int currentScore;
    private int startingScore = 0;

    private void Awake()
    {
        instance = this;    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScore = startingScore;
        UpdateDisplay();
    }

    public void IncreaseScoreByOne() 
    {
        // TODO: increase score number by one
        currentScore++;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        // TODO: update the score text to equal the score number
        scoreText.text = currentScore.ToString();
    }
}

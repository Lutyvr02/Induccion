using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text maxScoreText;
    public int Points;
    private int maxScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxscore", 0);
        pointText.text = "0";
        maxScoreText.text = "Max Score: " + maxScore;
    }
    public void addPoint ()   
    {
        Points += 1;
        pointText.text = ""+Points;

        if(maxScore < Points)
        {
            maxScore = Points;
            PlayerPrefs.SetInt("maxscore", maxScore);
            maxScoreText.text = "Max Score: " + maxScore;

        }
    }
}

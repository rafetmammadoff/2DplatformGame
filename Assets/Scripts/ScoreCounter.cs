using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int scoreCount;
    private float scoreCountTimerTreshold = 1;
    private float scoreCountTimer;
    private bool _canCountScore;
    public bool CanCountScore {
        get { return _canCountScore; }
        set { _canCountScore = value; }
    }

    private StringBuilder scoreStringBuilder = new StringBuilder();
    void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerTreshold;
    }

    // Update is called once per frame
    void Update()
    {

        if (!CanCountScore)
            return;

        //scoreCount += Time.deltaTime;
        //scoreTxt.text =  "x" + (int)scoreCount;

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshold;
            scoreCount++;
            DisplayScore(scoreCount);
        }
    }

    void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append("x");
        scoreStringBuilder.Append(score);

        scoreText.text = scoreStringBuilder.ToString();
    }

    public int GetScore()
    {
        return scoreCount;
    }
}

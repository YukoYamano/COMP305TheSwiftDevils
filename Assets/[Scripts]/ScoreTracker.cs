using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] int score;
    // Start is called before the first frame update
    void Start()
    {
        score = LivesStatic.score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score = LivesStatic.score;
       scoreText.text = score.ToString();
    }

    public void addScore(int amount)
    {
        LivesStatic.score += amount;
    }
}

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    private void Start()
    {
        string levelName = RestartButtonBehaviour.LastLevel;
        int score = Collecting.Score;
        int highscore = ScoreManager.GetHighscore(levelName);

        scoreText.text = "Score: " + score;
        highscoreText.text = "Highscore: " + highscore;
    }
}

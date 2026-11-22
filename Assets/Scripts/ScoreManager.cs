using UnityEngine;

public class ScoreManager
{
    public const int ApplePoints = 100;
    public const int LevelBonus = 500;
    public const int DeathPenalty = 100;

    public static void CollectApple()
    {
        Collecting.Score += ApplePoints;
    }

    public static void LoseLife()
    {
        Collecting.Score = Mathf.Max(0, Collecting.Score - DeathPenalty);
    }

    public static void CompleteLevel(string levelName)
    {
        Collecting.Score += LevelBonus;
        string key = "Highscore_" + levelName;
        int highscore = PlayerPrefs.GetInt(key, 0);

        if (Collecting.Score > highscore)
        {
            PlayerPrefs.SetInt(key, Collecting.Score);
            PlayerPrefs.Save();
        }
    }

    public static int GetHighscore(string levelName)
    {
        return PlayerPrefs.GetInt("Highscore_" + levelName, 0);
    }
}

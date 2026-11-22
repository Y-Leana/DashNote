using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonBehaviour : MonoBehaviour
{
    public static string LastLevel;
    public void OnButtonPress()
    {
        FallingDeath.Lives = 3;
        Collecting.Score = 0;
        Time.timeScale = 1f;
        //SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene(LastLevel);
    }
}

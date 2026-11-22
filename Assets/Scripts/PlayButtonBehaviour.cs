using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        FallingDeath.Lives = 3;
        Collecting.Score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stalemate");
    }
}

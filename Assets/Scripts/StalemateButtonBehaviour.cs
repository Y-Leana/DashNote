using UnityEngine;
using UnityEngine.SceneManagement;

public class StalemateButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        FallingDeath.Lives = 3;
        Collecting.Score = 0;
        SceneManager.LoadScene("Stalemate");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PHGButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        FallingDeath.Lives = 3;
        Collecting.Score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}

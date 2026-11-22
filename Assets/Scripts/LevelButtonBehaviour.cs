using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonBehaviour : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
}

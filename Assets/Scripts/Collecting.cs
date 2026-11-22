using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
    public AudioSource collectingSound;
    public static int Score = 0;
    public Text ScoreTextbox;

    void Start()
    {
        ScoreTextbox.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            collectingSound.Play();
            Score = Score + 1;
            ScoreManager.CollectApple();
            ScoreTextbox.text = Score.ToString();
        }
    }
}

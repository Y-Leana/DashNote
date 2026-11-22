using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpikeDeath : MonoBehaviour
{
    public Text LivesTextBox;
    public Transform Player;
    public Transform Camera;
    //public FallingDeath fallingDeath;

     public AudioSource dyingSound;
     public Movement movementScript;
    [SerializeField] public float ReturnToSpawnDuration = 0.3f;

    void Start()
    {
        LivesTextBox.text = FallingDeath.Lives.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(FallingDeath.Lives == 1)
            {
                //RestartButtonBehaviour.LastLevel =
                //SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                dyingSound.Play();
                movementScript.musicAudioSource.Stop();
                movementScript.ResetMovement();
                StartCoroutine(RespawnDelay());
            }
        }
    }

    IEnumerator RespawnDelay()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        FallingDeath.Lives = FallingDeath.Lives -1;
        ScoreManager.LoseLife();
        LivesTextBox.text = FallingDeath.Lives.ToString();
        Player.transform.position = new Vector2(-7.5f, -2.88f);

        CameraControl camControl = Camera.GetComponent<CameraControl>();
        if (camControl != null) camControl.enabled = false;
            
        
        //Camera.transform.position = new Vector3(0, 0, -10);
        yield return StartCoroutine(PanCameraToSpawn());
        //
        if(camControl != null) camControl.enabled = true;
        movementScript.ResetMusic();
    }

    IEnumerator PanCameraToSpawn()
    {
        Vector3 startPos = Camera.position;
        Vector3 endPos = new Vector3 (0, 0, -10);
        float elapsed = 0f;

        while (elapsed < ReturnToSpawnDuration)
        {
            elapsed += Time.deltaTime;
            Camera.position = Vector3.Lerp(startPos, endPos, elapsed / ReturnToSpawnDuration);
            yield return null;
        }
        
        Camera.position = endPos;

    }
}

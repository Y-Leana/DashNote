using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FallingDeath : MonoBehaviour
{
    public static int Lives = 3;
    public Text LivesTextBox;
    public Transform Player;
    public Transform Camera;
    public AudioSource dyingSound;
    public Movement movementScript;
    [SerializeField] public float ReturnToSpawnDuration = 0.3f;

    void Start()
    {
        LivesTextBox.text = Lives.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(Lives == 1)
            {
                //RestartButtonBehaviour.LastLevel =
                //SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                dyingSound.Play();
                movementScript.musicAudioSource.Stop();
               // movementScript.musicAudioSource.Stop();
                //movementScript.musicAudioSource.time = 0f;
                //movementScript.musicAudioSource.Play();
                StartCoroutine(RespawnDelay());
            }
        }
    }

    IEnumerator RespawnDelay()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        Lives = Lives -1;
        ScoreManager.LoseLife();
        LivesTextBox.text = Lives.ToString();

        /*Movement movementScript = Player.GetComponent<Movement>();
        if(movementScript != null)
        {
            movementScript.ResetMusic();
        }*/

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

using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpingSpeed;
    private Rigidbody2D body;
    private bool grounded;
    public AudioSource musicAudioSource;
    float timeLastFrame = 0;
    float deltaTime = 0;
    public bool isPaused = false;
    public GameObject pauseMenu;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            ScoreManager.CompleteLevel(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Win");
        }
    }

    private IEnumerator RotateSmoothly(float angle)
    {
        float duration = 0.5f;
        float elapsed = 0f;
        float currentY = transform.eulerAngles.y;
        float startZ = transform.eulerAngles.z;
        float endZ = startZ + angle;

        while (elapsed < duration)
        {
            float z = Mathf.Lerp(startZ, endZ, elapsed / duration);
            transform.rotation = Quaternion.Euler(0f, currentY, z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0f, currentY, endZ);
    }
    
    // Update is called once per frame
    public void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            PauseGame();
        }

        if (isPaused || musicAudioSource == null) return;

        //deltaTime = musicAudioSource.time - timeLastFrame;
        //timeLastFrame = musicAudioSource.time;

        //if(deltaTime < 0) deltaTime = 0;
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (Keyboard.current.spaceKey.isPressed && grounded)
        {
            //StartCoroutine(RotateSmoothly(-90f)); //rotate when jump
            body.linearVelocity = new Vector2(body.linearVelocity.x, JumpingSpeed);
            grounded = false;
        }
    }

    public void Start()
    {
        Collecting.Score = 0;
        RestartButtonBehaviour.LastLevel = SceneManager.GetActiveScene().name;
    }

     public void ResetMusic()
    {
        if (musicAudioSource != null)
        {
            //musicAudioSource.Stop();
            musicAudioSource.time = 0f;
            musicAudioSource.Play();
        }

        transform.rotation = Quaternion.identity;
    }

     public void ResetMovement()
    {
        body.linearVelocity = Vector2.zero;
        grounded = false;
    }

    public void PauseGame()
    {
        isPaused = true;

        Time.timeScale = 0f;
        musicAudioSource.Pause();
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;

        Time.timeScale = 1f;
        musicAudioSource.UnPause();
        pauseMenu.SetActive(false);
    }
}


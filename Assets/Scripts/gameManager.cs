using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawner;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject getReady;
    public int score;
    public AudioSource audioSource;
    public AudioClip hitObstacle;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        getReady.SetActive(true);
        scoreText.enabled = false;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);
        scoreText.enabled = true;

        Time.timeScale = 1f;
        player.SetActive(true);

        pipes[] pipesToDestroy = FindObjectsOfType<pipes>();

        for (int i = 0; i < pipesToDestroy.Length; i++) {
            Destroy(pipesToDestroy[i].gameObject);
        }
    }

    public void GameOver()
    {
        audioSource.clip = hitObstacle;
        audioSource.Play();
    
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
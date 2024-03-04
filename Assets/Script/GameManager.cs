
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public AudioSource backgroundMusic;
    public AudioSource gameOverSound;

    private int score;
    private bool isMusicPlaying = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

public void Play()
{
    score = 0;
    scoreText.text = score.ToString();

    playButton.SetActive(false);
    gameOver.SetActive(false);

    Time.timeScale = 1f;
    player.enabled = true;

    Pipes[] pipes = FindObjectsOfType<Pipes>();

    for (int i = 0; i < pipes.Length; i++)
    {
        Destroy(pipes[i].gameObject);
    }

    if (!isMusicPlaying)
    {
        backgroundMusic.PlayOneShot(backgroundMusic.clip);
        isMusicPlaying = true;
    }
    else
    {
        // Прерываем воспроизведение музыки геймовера при повторном нажатии на Play
        gameOverSound.Stop();
        isMusicPlaying = false;
    }
}


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        backgroundMusic.Pause();
    }

    public void GameOver()
{
    playButton.SetActive(true);
    gameOver.SetActive(true);

    Pause();

    if (isMusicPlaying)
    {
        gameOverSound.Play();
        isMusicPlaying = false;
    }
}
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}

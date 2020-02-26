using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip ButtonClick;
    public AudioClip Lose;
    public AudioClip ScoreSound;
    public AudioClip ButtonOver;
    public AudioClip BirdJump;
    public Text HighScore;
    int Score = 0;
    public Text scoreText;
    public static GameManager instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollingSpeed = -10.0f;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BirdScored()
    {
        if(gameOver == true)
        {
            return;
        }
        Score++;
        playSoundScore();
        scoreText.text = "Score: " + Score.ToString();
    }
    public void BirdDied()
    {
        SaveHighScore();
        HighScore.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
        gameOverText.SetActive(true);
        playSoundLose();
        gameOver = true;
    }
    public void RestartButton()
    {
        playSoundButtonClick();
        SceneManager.LoadScene(0);
        playSoundButtonOver();
    }
    public void ExitButton()
    {
        GameManager.instance.playSoundButtonClick();
        Application.Quit();
        GameManager.instance.playSoundButtonOver();
    }
    public void SaveHighScore()
    {
        if(Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
        PlayerPrefs.SetFloat("HighScore", Score);
        }    
    }
    public void playSoundJump()
    {
        GameObject gameObject = new GameObject( "SoundJump", typeof(AudioSource) );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(BirdJump);
    }
    public void playSoundButtonClick()
    {
        GameObject gameObject = new GameObject( "SoundButtonClick", typeof(AudioSource) );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(ButtonClick);
    }
    public void playSoundLose()
    {
        GameObject gameObject = new GameObject( "SoundButtonClick", typeof(AudioSource) );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(Lose);
    }
    public void playSoundScore()
    {
        GameObject gameObject = new GameObject( "SoundButtonClick", typeof(AudioSource) );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(ScoreSound);
    }
    public void playSoundButtonOver()
    {
        GameObject gameObject = new GameObject( "SoundButtonClick", typeof(AudioSource) );
        AudioSource audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.PlayOneShot(ButtonOver);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 10f;
    public int score;
    public Text scoreText;
    public GameObject deathPanel;
    public Text deathScoreText;
    public Text deathRecordText;
    public int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScoreSave");
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, moveVector.y);
        scoreText.text = score.ToString();
        deathScoreText.text = "score: " + score.ToString();
        deathRecordText.text = "highest score: " + highScore.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScoreSave", highScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathCube"))
        {
            Destroy(gameObject);
            score = 0;
            deathPanel.SetActive(true);
            
        }

        if (collision.CompareTag("50Points"))
        {
            Destroy(collision.gameObject);
            score += 50;
            scoreText.text = score.ToString();
        }

        if(collision.CompareTag("10Points"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = score.ToString();
        }

        if(collision.CompareTag("0.5Speed"))
        {
            StartCoroutine(SpeedDecrease());
        }

        IEnumerator SpeedDecrease()
        {
            speed = speed / 2;
            yield return new WaitForSeconds(10);
            speed = 10;
        }
    }

    public void ResetHighscore()
    {
        highScore = 0;
        deathRecordText.text = "highest score: " + highScore.ToString();
    }
}

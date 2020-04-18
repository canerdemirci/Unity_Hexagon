using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 600.0f;
    public Text scoreText;
    public Text welcomeText;
    public Text startBtnText;
    public Text imzaText;
    public Text enyuksekPuanText;

    float movement = 0.0f;
    float touchPoint = 1.0f;
    int score = 0;
    bool isPlaying = false;
    float restartTimer = 2.0f;
    bool doRestart = false;

    void Start()
    {
        Time.timeScale = 0.0f;

        int puan = ReadSaveData();
        enyuksekPuanText.text = "En Yüksek Puan: " + puan;
    }

    void Update()
    {
        if (!isPlaying)
        {
            if (Input.touchCount > 0 || Input.GetAxisRaw("Horizontal") > 0)
            {
                scoreText.gameObject.SetActive(true);
                welcomeText.gameObject.SetActive(false);
                startBtnText.gameObject.SetActive(false);
                imzaText.gameObject.SetActive(false);
                enyuksekPuanText.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                isPlaying = true;
            }
        }
        else
        {
            movement = Input.GetAxisRaw("Horizontal");

            foreach(Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Stationary)
                {
                    touchPoint = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 0)).x;

                    if (touchPoint > 0.5)
                        movement = 1.0f;
                    else
                        movement = -1.0f;
                }
            }

            score = (int)Mathf.Ceil(Time.timeSinceLevelLoad) * 10;
            scoreText.text = "Puan: " + score.ToString();
        }

        if (doRestart)
        {
            Restart();
        }
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        doRestart = true;
    }

    void Restart()
    {
        SaveGame();
        Time.timeScale = 0.0f;
        restartTimer -= Time.unscaledDeltaTime;
        if (restartTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    int ReadSaveData()
    {
        return PlayerPrefs.GetInt("puan", 0);
    }

    void SaveGame()
    {
        int puan = ReadSaveData();

        if (score > puan) {
            PlayerPrefs.SetInt("puan", score);
            PlayerPrefs.Save();
        }
    }
}

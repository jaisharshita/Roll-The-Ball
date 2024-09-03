using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //variables: 

    // to move player 
    public Rigidbody movePlayer;
    public float forceAmount = 1f;

    //to jump player
    public float JumpSpeed;
    public bool isGrounded;

    //to show and increase score
    public TextMeshProUGUI Score;
    public int ScoreIncrease = 0;

    //to show and decrease health
    public Slider HealthSlider;
    public float decreaseAmount = 0.02f;

    //to show pop-ups
    public GameObject YouLoose;
    public GameObject YouWon;

    public GameObject CoinCollectSound, JumpSound, DangerSound, WinSound;

    //not win yet
    public int totalCoinsRequired = 11;
    public GameObject lessCoins;


    void Start()
    {
        movePlayer = GetComponent<Rigidbody>();
        Score.text = ScoreIncrease.ToString();

    }
    void Update()
    {
        jump();
        if (Input.GetKey(KeyCode.D))
        {
            movePlayer.AddForce(Vector3.right * forceAmount);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movePlayer.AddForce(Vector3.left * forceAmount);
        }

    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpSound.GetComponent<AudioSource>().Play();
            movePlayer.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "dBox")
        {
            DangerSound.GetComponent<AudioSource>().Play();
            DecreaseSliderValue(decreaseAmount);
        }
    }

    private void DecreaseSliderValue(float amount)
    {
        if (HealthSlider != null)
        {
            HealthSlider.value -= amount;
        }

        if (HealthSlider.value <= 0)
        {
            Debug.Log("you loose the Gameeeeeee");
            YouLoose.gameObject.SetActive(true);
        }

    }

    public void NotEnoughCoins()
    {
        lessCoins.SetActive(true);
    }
    private void close()
    {
        lessCoins.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coins")
        {
            CoinCollectSound.GetComponent<AudioSource>().Play();
            ScoreIncrease++;
            Score.text = ScoreIncrease.ToString();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "complete")
        {
            if (ScoreIncrease >= totalCoinsRequired)
            {
                YouWon.SetActive(true);
                WinSound.GetComponent<AudioSource>().Play();
            }
            else
            {
                NotEnoughCoins();
                Invoke("close", 2.0f);
            }
        }

        if (other.gameObject.tag == "fire")
        {
            DangerSound.GetComponent<AudioSource>().Play();
            DecreaseSliderValue(decreaseAmount);
            other.gameObject.SetActive(false);
        }
    }

    
    public void RetryLevel1()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }

    public void ToMainScene()
    {
        Application.LoadLevel(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
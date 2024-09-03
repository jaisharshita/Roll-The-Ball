using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 600f; // Starting time in seconds
    private float timeRemaining;
    public TextMeshProUGUI countdownText;
    public GameObject YouLoose; // UI element to display when time is up
    int dtacheck = 0; // Variable to display when time is up (optional)

    void Start()
    {
        timeRemaining = startTime;
        UpdateCountdownText(); // Initial update of the countdown text
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        // Ensure timeRemaining does not go negative
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            YouLoose.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("You lose the game");
        }

        UpdateCountdownText(); // Update the countdown text
    }
    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

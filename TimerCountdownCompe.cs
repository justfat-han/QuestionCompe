using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCountdownCompe: MonoBehaviour
{
    [SerializeField]
    private float startTimeInSeconds = 30f;  // Starting time for the countdown in seconds

    [SerializeField]
    private TextMeshProUGUI timerText;  // Reference to the TextMeshProUGUI component for displaying the timer

    private float timeRemaining;
    private bool isCountingDown = false;

    private void Start()
    {
        // Initialize the timer
        timeRemaining = startTimeInSeconds;
        UpdateTimerDisplay();
        StartCountdown();
    }

    private void Update()
    {
        // Only update the timer if it's counting down
        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isCountingDown = false;
                TimerEnded();
            }
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        // Convert the time remaining to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the timerText display
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartCountdown()
    {
        // Start the countdown
        isCountingDown = true;
    }

    public void DeductTime(float seconds)
    {
        // Deduct time from the remaining time
        timeRemaining -= seconds;

        // Ensure time doesn't go below zero
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            isCountingDown = false;
            TimerEnded();
        }

        // Update the timer display immediately after deduction
        UpdateTimerDisplay();
    }

    private void TimerEnded()
    {
        // Handle what happens when the timer ends
        Debug.Log("Timer has ended!");
        // You can trigger any other event here, like ending the game, showing a message, etc.
    }
}


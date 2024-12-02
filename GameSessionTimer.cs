using TMPro;
using UnityEngine;
using UnityEngine.UI; // If you want to display the time on a UI Text component

public class GameSessionTimer : MonoBehaviour
{
    // Private variable to track start time
    private float sessionStartTime;

    // Public variable to store total play time
    public float totalPlayTime { get; private set; }

    // Optional UI Text component to display time
    public TextMeshProUGUI timeDisplayText;

    void Start()
    {
        // Record the start time when the game begins
        sessionStartTime = Time.time;
    }

    void Update()
    {
        // Calculate total play time
        totalPlayTime = Time.time - sessionStartTime;

        // Optional: Update UI Text with formatted time (uncomment if using UI)
        if (timeDisplayText != null)
        {
            timeDisplayText.text = FormatTime(totalPlayTime);
        }
    }

    // Call this method when the game session ends
    public void EndSession()
    {
        // Stop the timer and display total play time
        float finalPlayTime = Time.time - sessionStartTime;
        
        // You can log the time or perform any end-of-session actions
        Debug.Log($"Total Play Time: {FormatTime(finalPlayTime)}");

        // Optional: Save play time to PlayerPrefs
        PlayerPrefs.SetFloat("LastSessionPlayTime", finalPlayTime);
        PlayerPrefs.Save();
    }

    // Helper method to format time into minutes and seconds
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Optional method to get the total play time as a formatted string
    public string GetFormattedPlayTime()
    {
        return FormatTime(totalPlayTime);
    }
}

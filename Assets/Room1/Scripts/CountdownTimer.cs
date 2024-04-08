using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text timerText; // Reference to the text component displaying the timer
    public float initialCountdownDuration = 20f; // Duration of the initial countdown timer
    public float secondaryCountdownDuration = 60f; // Duration of the secondary countdown timer

    void Start()
    {
        // Start the initial countdown timer
        StartCoroutine(StartInitialCountdown());
    }

    IEnumerator StartInitialCountdown()
    {
        float timer = initialCountdownDuration;

        while (timer > 0)
        {
            // Update the timer text
            timerText.text = timer.ToString("F0");

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrease the timer
            timer--;
        }

        // After the initial countdown, start the secondary countdown
        StartCoroutine(StartSecondaryCountdown());
    }

    IEnumerator StartSecondaryCountdown()
    {
        float timer = secondaryCountdownDuration;

        while (timer > 0)
        {
            // Update the timer text
            timerText.text = timer.ToString("F0");

            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrease the timer
            timer--;
        }

        // Ensure timer text shows 0 when secondary countdown is finished
        timerText.text = "0";
    }
}

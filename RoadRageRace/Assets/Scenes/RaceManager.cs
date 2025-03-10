using UnityEngine;
using System.Collections;
using TMPro;  // Import TextMeshPro namespace

public class RaceManager : MonoBehaviour
{
    public PlayerCarController player1;
    public PlayerCarController player2;
    public TMP_Text countdownText; // Reference to your TextMeshPro text component

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "3";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "GO!";
        AudioManager.Instance.PlayStartSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "";

        player1.StartRace();
        player2.StartRace();
    }
}
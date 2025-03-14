using UnityEngine;
using System.Collections;
using Unity.Netcode;
using TMPro;

public class RaceManager : NetworkBehaviour
{
    public PlayerCarController player1;
    public PlayerCarController player2;
    public TMP_Text countdownText;


    public override void OnNetworkSpawn()
    {
            StartCoroutine(StartCountdown());
        
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "10";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "9";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "8";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "7";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "6";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "5";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
        countdownText.text = "4";
        AudioManager.Instance.PlayCountdownSound();
        yield return new WaitForSeconds(1);
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

    }
}


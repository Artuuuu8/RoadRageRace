using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool raceFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!raceFinished && other.CompareTag("Player"))
        {
            raceFinished = true; // Prevent multiple triggers


            // Find the UIManager and display the finish UI
            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null)
            {
                uiManager.ShowFinish("1st Place!");
                AudioManager.Instance.PlayFinishSound();

            }
        }
    }
}
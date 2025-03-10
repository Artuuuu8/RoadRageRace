using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool raceFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("FinishLine triggered by: " + other.gameObject.name);
        if (!raceFinished && other.CompareTag("Player"))
        {
            raceFinished = true; // Prevent multiple triggers
            Debug.Log("FinishLine: Player detected. Finishing race!");

            // Optionally, you could stop player movement here

            // Find the UIManager and display the finish UI
            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null)
            {
                uiManager.ShowFinish("1st Place!");
                Debug.Log("FinishLine: UIManager found, finish UI displayed.");
            }
            else
            {
                Debug.LogWarning("FinishLine: UIManager not found in the scene.");
            }
        }
    }
}
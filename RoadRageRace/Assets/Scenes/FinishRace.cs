using UnityEngine;

public class FinishRace : MonoBehaviour
{
    private bool raceStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine") && raceStarted)
        {
            Debug.Log(gameObject.name + " WINS!");
            // Here you can stop the game, show a UI message, or restart the race
        }
    }

    public void StartRace()
    {
        raceStarted = true;
    }
}

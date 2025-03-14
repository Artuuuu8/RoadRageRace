using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine;

public class ConnectUI : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button joinButton;

    private void Start()
    {
        hostButton.onClick.AddListener(HostButtonOnClick);
        joinButton.onClick.AddListener(JoinButtonOnClick);
    }

    private void HostButtonOnClick()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void JoinButtonOnClick()
    {
        NetworkManager.Singleton.StartClient();
    }
}
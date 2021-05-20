using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        LobbyManager lobbyManager = new LobbyManager();
        lobbyManager.Init();
    }

}

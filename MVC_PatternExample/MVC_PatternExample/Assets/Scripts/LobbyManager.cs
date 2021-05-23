using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager
{
    UILobbyController _uiLobbyController;
    UIWorldMapController _uiWorldMapController;
    UIShopController _uiShopController;
    public void Init()
    {
        _uiLobbyController = UIManager.instance.CreateController<UILobbyController>(UIType.Lobby);

        _uiLobbyController.Init();
    }
    
}

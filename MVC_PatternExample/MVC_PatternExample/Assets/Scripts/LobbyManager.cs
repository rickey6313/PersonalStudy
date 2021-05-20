using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager
{
    UIWorldMapController _uiWorldMapController;
    UIShopController _uiShopController;
    public void Init()
    {
        Debug.Log("LobbyManager Init");

        _uiWorldMapController = UIManager.instance.CreateController<UIWorldMapController>(UIType.WorldMap);

        if(_uiWorldMapController != null)
        {
            _uiWorldMapController.Init();
        }
    }
    
}

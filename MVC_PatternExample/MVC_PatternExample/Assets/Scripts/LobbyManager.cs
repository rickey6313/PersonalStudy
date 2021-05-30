using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager
{
    private static LobbyManager _instance;
    public static LobbyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LobbyManager();
            }

            return _instance;
        }
    }
    
    UILobbyController _uiLobbyController;
    UIWorldMapController _uiWorldMapController;
    UIShopController _uiShopController;

    List<ControllerType> ctrlTypes = new List<ControllerType>();
    ControllerType _curControllerType;

    public void Init()
    {
        _uiLobbyController = UIManager.Instance.CreateController<UILobbyController>(ControllerType.Lobby);        
    }
    
    public void CallController(ControllerType ctrlType, TransitionType transitionType)
    {   
        UIManager.Instance.TransitionOn(transitionType, ControllerInit);
    }

    public void CallMultiControllers(List<ControllerType> ctrlTypes, TransitionType transitionType)
    {
        UIManager.Instance.TransitionOn(transitionType, MultyControllerInit);
    }

    private void ControllerInit()
    {

    }

    private void MultyControllerInit()
    {

    }
}

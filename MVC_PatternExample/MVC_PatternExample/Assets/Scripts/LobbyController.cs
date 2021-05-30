using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UILobbyController : BaseUIController
{
    UILobbyView _uiLobbyView;
    public override void Init()
    {
        _uiLobbyView = UIManager.Instance.CreatePrefabs<UILobbyView>(ControllerType.Lobby);
    }

    public override void Activate()
    {
        _uiLobbyView?.Activate();
    }

    public override void Deactivate()
    {
        _uiLobbyView?.Deactivate();
    }

    public void CallController(int index)
    {
        switch(index)
        {
            case 1:
                LobbyManager.Instance.CallController(ControllerType.WorldMap, TransitionType.Loading);
                break;
            case 2:
                LobbyManager.Instance.CallController(ControllerType.Shop, TransitionType.Loading);
                break;
            case 3:
                LobbyManager.Instance.CallController(ControllerType.Type3, TransitionType.Loading);
                break;
        }
    }
}


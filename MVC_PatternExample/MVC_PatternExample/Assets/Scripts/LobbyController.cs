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
        _uiLobbyView = UIManager.instance.CreatePrefabs<UILobbyView>(UIType.Lobby);
    }

    public override void Activate()
    {
        _uiLobbyView?.Activate();
    }

    public override void Deactivate()
    {
        _uiLobbyView?.Deactivate();
    }
}


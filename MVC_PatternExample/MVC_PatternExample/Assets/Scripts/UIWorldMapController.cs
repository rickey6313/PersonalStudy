using System;
using System.Collections.Generic;


public class UIWorldMapController : BaseUIController
{
    UIWorldMapView _uiWorldMapView;
    public override void Init()
    {
        _uiWorldMapView = UIManager.Instance.CreatePrefabs<UIWorldMapView>(ControllerType.WorldMap);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public enum CameraDepth
    {
        CameraDeth1
    }

    [SerializeField]
    private Canvas _rootCanvas1;

    public static UIManager Instance;

    private BaseUIController _curController;
    private Stack<BaseUIController> _uiControllerStack = new Stack<BaseUIController>();
    private Dictionary<ControllerType, BaseUIController> _uiControllerDict = new Dictionary<ControllerType, BaseUIController>();
    private Dictionary<ControllerType, string> _uiPrefabsNameDict = new Dictionary<ControllerType, string>()
    {
        {ControllerType.Lobby, "Lobby" },
        {ControllerType.WorldMap, "WorldMap" } 
    
    };

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public BaseUIController GetController(ControllerType type)
    {
        if (_uiControllerDict.ContainsKey(type))
            return _uiControllerDict[type];
        else
            return null;
    }

    public T CreatePrefabs<T>(ControllerType type, CameraDepth depth = CameraDepth.CameraDeth1) where T : BaseOutGameUIView
    {
        var root = GetCameraDepth(depth);
        var loaded = Resources.Load<T>($"Prefabs/{_uiPrefabsNameDict[type]}");
        var instance = Instantiate(loaded, Vector3.zero, Quaternion.identity);
        instance.transform.SetParent(root);
        instance.transform.localPosition = Vector3.zero;
        return instance;
    }

    private Transform GetCameraDepth(CameraDepth depth)
    {
        switch(depth)
        {
            case CameraDepth.CameraDeth1:
                return _rootCanvas1.transform;

            default:
                return _rootCanvas1.transform;
        }
        
    }

    public T CreateController<T>(ControllerType type) where T : BaseUIController
    {
        if (_uiControllerDict.ContainsKey(type))
            return _uiControllerDict[type] as T;

        switch (type)
        {
            case ControllerType.Lobby:
                var lobby = new UILobbyController();
                _uiControllerDict[type] = lobby as T;
                return lobby as T;
            case ControllerType.WorldMap:
                var worldMap = new UIWorldMapController();
                _uiControllerDict[type] = worldMap as T;
                return worldMap as T;
            case ControllerType.Shop:
                var shop = new UIWorldMapController();
                _uiControllerDict[type] = shop as T;
                return shop as T;
            case ControllerType.Type3:
                break;
        }
        return null;
    }

    private void PushController(BaseUIController ctrl)
    {   
        if (_uiControllerStack.Contains(ctrl))
        {   
            Stack<BaseUIController> tempStack = new Stack<BaseUIController>();
            while(_uiControllerStack.Contains(ctrl))
            {
                tempStack.Push(_uiControllerStack.Pop());
            }
            tempStack.Pop();
            while (tempStack.Count > 0)
                _uiControllerStack.Push(tempStack.Pop());
        }
        _uiControllerStack.Push(ctrl);
    }

    public void TransitionOn(TransitionType transitionType, Action callback)
    {
        UITransition.Instance.TransitionOn(transitionType, callback);
    }

    public void TransitionOff(Action callback, Action endCallback)
    {
        UITransition.Instance.TransitionOff(callback, endCallback);
    }

    public void ActivateController(ControllerType type, bool isPush = false)
    {
        if(_curController != null)
        {
            _curController.Deactivate();
        }
        var nextCtrl = GetController(type);

        if(isPush)
            PushController(nextCtrl);
        _curController = nextCtrl;

        nextCtrl.Activate();
    }

    public void DeactivateController()
    {
        if (_curController != null)
        {
            _curController.Deactivate();
        }


    }

    public void CloseCurrentController()
    {
        if (_curController == _uiControllerStack.Peek())
            _uiControllerStack.Pop();
        else
            DeactivateController();
    }
}

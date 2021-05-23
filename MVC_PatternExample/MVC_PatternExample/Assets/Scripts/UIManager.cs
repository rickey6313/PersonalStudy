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

    public static UIManager instance;

    private BaseUIController _curController;
    private Stack<BaseUIController> _uiControllerStack = new Stack<BaseUIController>();
    private Dictionary<UIType, BaseUIController> _uiControllerDict = new Dictionary<UIType, BaseUIController>();
    private Dictionary<UIType, string> _uiPrefabsNameDict = new Dictionary<UIType, string>()
    {
        {UIType.Lobby, "Lobby" },
        {UIType.WorldMap, "WorldMap" } 
    
    };

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public BaseUIController GetController(UIType type)
    {
        if (_uiControllerDict.ContainsKey(type))
            return _uiControllerDict[type];
        else
            return null;
    }

    public T CreatePrefabs<T>(UIType type, CameraDepth depth = CameraDepth.CameraDeth1) where T : BaseOutGameUIView
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

    public T CreateController<T>(UIType type) where T : BaseUIController
    {
        if (_uiControllerDict.ContainsKey(type))
            return _uiControllerDict[type] as T;

        switch (type)
        {
            case UIType.Lobby:
                var lobby = new UILobbyController();
                _uiControllerDict[type] = lobby as T;
                return lobby as T;
            case UIType.WorldMap:
                var worldMap = new UIWorldMapController();
                _uiControllerDict[type] = worldMap as T;
                return worldMap as T;
            case UIType.Shop:
                var shop = new UIWorldMapController();
                _uiControllerDict[type] = shop as T;
                return shop as T;
            case UIType.Type3:
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

    public void ActivateController(UIType type, bool isPush = false)
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

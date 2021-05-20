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

    private Dictionary<UIType, BaseUIController> _uiControllerDict = new Dictionary<UIType, BaseUIController>();
    private Dictionary<UIType, string> _uiPrefabsNameDict = new Dictionary<UIType, string>()
    { 
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

    public T CreatePrefabs<T>(UIType type, CameraDepth depth = CameraDepth.CameraDeth1) where T : MonoBehaviour
    {
        var root = GetCameraDepth(depth);
        Debug.Log($"Prefabs/{_uiPrefabsNameDict[type]}");
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

    public void ActivateController(UIType type)
    {

    }
}

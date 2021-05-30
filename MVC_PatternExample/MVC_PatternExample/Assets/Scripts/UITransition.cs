using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransition : MonoBehaviour
{
    public static UITransition Instance = new UITransition();

    bool _isTransitionStart = false;

    TransitionType _transitionType;
    Action _callback;
    Action _endCallback;

    private void Awake()
    {
        Instance = GetComponent<UITransition>();
        if(Instance == null)
        {
            Instance = gameObject.AddComponent<UITransition>();
        }
        DontDestroyOnLoad(this);
    }

    public void TransitionOn(TransitionType transitionType, Action callback)
    {
        _transitionType = transitionType;
        _callback = callback;
        SwitchTransition();
    }

    public void TransitionOff(Action callback, Action endCallback = null)
    {
        _callback = callback;
        _endCallback = endCallback;
        SwitchTransition();
    }

    public void SwitchTransition()
    {
        switch (_transitionType)
        {
            case TransitionType.Loading:
                if(_isTransitionStart)
                    StartCoroutine(LoadingOff());
                else
                    StartCoroutine(LoadingOn());                
                break;
            case TransitionType.Fade:
                break;
        }
    }

    IEnumerator LoadingOn()
    {
        Debug.Log("LoadingStart");
        _isTransitionStart = true;
        yield return null;
        _callback?.Invoke();
    }

    IEnumerator LoadingOff()
    {
        Debug.Log("LoadingOff");        
        _callback?.Invoke();
        yield return null;
        _isTransitionStart = false;
        Debug.Log("LoadingEnd");
        _endCallback?.Invoke();
    }
}

using System;
using System.Collections.Generic;


public class BaseUIController
{
    Action _readyToAction;
    Action _transitionEnd;

    public virtual void Init() { }
    public virtual void Activate() { }
    public virtual void Deactivate() { }

    public void SetAction(Action readyToAction, Action transitionEnd)
    {
        _readyToAction = readyToAction;
        _transitionEnd = transitionEnd;
    }
}


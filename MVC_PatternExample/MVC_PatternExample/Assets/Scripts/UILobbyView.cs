using System.Collections;
using UnityEngine;

public class UILobbyView : BaseOutGameUIView
{

    public override void Activate()
    {
        gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

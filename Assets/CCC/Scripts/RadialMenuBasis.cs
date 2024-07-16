using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

public class RadialMenuBasis : RadialMenu
{
    protected void Start()
    {
        Logger.Debug(">>> ViuCCC.Start");
        FindTheCCC();
        if (!TheCCC)
        {
            Logger.Fatal("CCC Objekt wurde nicht gefunden!");
            return;
        }
        
        if (CCCHand == HandRole.LeftHand) 
        {
            Logger.Debug("Verwendeter Controller: Links!");
            m_Controller = GameObject.Find("LeftHand");
            if (!m_Controller)
            {
                Logger.Fatal("Linker Controller nicht gefunden!");
                return;            
            }
            m_ControllerCollider = GameObject.Find("Right");
        }
        else
        {
            Logger.Debug("Verwendeter Controller: Rechts!");
            m_Controller = GameObject.Find("RightHand");
            if (!m_Controller)
            {
                Logger.Fatal("Rechter Controller nicht gefunden!");
                return;            
            }
            m_ControllerCollider = GameObject.Find("Left");   
        }
        
        Logger.Debug("<<< ViuCCC.Start");
        SetPositionAndRotation();
        
        TheCCC.SetActive(Show);
    }

    // Position is bound to controller position, orientation faces the camera 
    protected virtual void SetPositionAndRotation() {}
}

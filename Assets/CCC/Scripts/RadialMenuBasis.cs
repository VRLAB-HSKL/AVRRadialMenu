//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interface und Implementierung des Radial Menus
/// abgeleitet von RadialMenu und implementiert
/// das Radial Menu mit Collidern
/// auf Basis von Vive Input Utility.
/// </summary>
public class RadialMenuBasis : RadialMenu
{
    /// <summary>
    /// CCC-Objekt finden und alles initialisieren
    /// </summary>
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

	/// <summary>
    /// Festlegen der Positionierung und Orientierung des Radial Menus.
    /// </summary>
    protected virtual void SetPositionAndRotation() {}
}

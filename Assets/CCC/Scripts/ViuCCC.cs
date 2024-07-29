//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Radial Menu mit Collidern, das sich der Stelle des Controllers erscheint.
/// </summary>
public class ViuCCC : RadialMenuBasis
{ 
	/// <summary>
    /// Festlegen der Positionierung und Orientierung des Radial Menus.
    /// </summary>
    protected override void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            m_Controller.transform.position, 
            m_Controller.transform.rotation);        
    }
}

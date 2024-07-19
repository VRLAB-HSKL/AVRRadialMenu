//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Radial Menu mit Trackpad, das sich um den Controller anordnet.
/// </summary>
public class ViuCCCTrackpad : RadialMenuTrackpadBasis
{ 
	/// <summary>
    /// Festlegen der Positionierung und Orientierung des Radial Menus.
    /// </summary>
    protected override void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            m_Controller.transform.position,
            Camera.main.transform.rotation);
    }
}
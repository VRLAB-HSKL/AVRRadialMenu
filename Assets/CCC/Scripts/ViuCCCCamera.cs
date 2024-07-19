//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Radial Menu mit Collidern, das sich vor der Kamera befindet.
/// </summary>
public class ViuCCCCamera : RadialMenuBasis
{ 
	/// <summary>
    /// Festlegen der Positionierung und Orientierung des Radial Menus.
    /// </summary>
    protected virtual void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            Camera.main.transform.position + Camera.main.transform.forward * 0.6f,
            Camera.main.transform.rotation);
    }

	/// <summary>
    /// Positionierung und Rotation des Radial Menus wird durchgängig geupdated,
	/// sodass sie sich den Bewegungen des Nutzers anpassen.
    /// </summary>
     void Update()
     {
         SetPositionAndRotation();
     }

}
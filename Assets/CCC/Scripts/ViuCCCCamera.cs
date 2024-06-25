//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

/// <summary>
// /Interface und Implementierung des Command Control Cube
/// auf Basis von Vive Input Utility..
/// </summary>
/// <remarks>
/// Die von dieser Klaasse abgeleiteten Versionen verwenden entweder
/// das Input System und Unity XR oder Vive Input Utility.
/// </remarks>
public class ViuCCCCamera : RadialMenuBasis
{ 
    protected void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            Camera.main.transform.position + Camera.main.transform.forward * 0.6f,
            Camera.main.transform.rotation);
    }

     void Update()
     {
         SetPositionAndRotation();
     }

}
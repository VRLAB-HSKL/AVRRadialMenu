//========= 2023 - -2024 Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

public class ViuCCCTrackpad : RadialMenuTrackpadBasis
{ 
    protected override void SetPositionAndRotation()
    {
        TheCCC.transform.SetPositionAndRotation(
            m_Controller.transform.position,
            Camera.main.transform.rotation);
    }
}
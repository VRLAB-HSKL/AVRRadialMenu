using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

public class RadialMenuTrackpadBasis : RadialMenu
{
    protected float x_, y_, angle;
    protected int newIndex;
    protected int segments = 4;
    protected GameObject[] cubes;
 
    protected void Start()
    {
        cubes = new GameObject[segments];
        cubes[0] = GameObject.Find("CC0");
        cubes[1] = GameObject.Find("CC1");
        cubes[2] = GameObject.Find("CC2");
        cubes[3] = GameObject.Find("CC3");

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
            m_ControllerCollider = GameObject.Find("Left");
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
            m_ControllerCollider = GameObject.Find("Right");
        }
        
        Logger.Debug("<<< ViuCCC.Start");
        SetPositionAndRotation();
        
        TheCCC.SetActive(Show);
    }
    

    protected void Update()
    {
        SetPositionAndRotation();
        y_ = ViveInput.GetAxis(CCCHand, ControllerAxis.PadY);
        x_ = ViveInput.GetAxis(CCCHand, ControllerAxis.PadX);
        PolarCoordinates(segments, x_, y_);
		GameObject kapsel = GameObject.Find("Kapsel");
		Mover mover = kapsel.GetComponent<Mover>();
        // map cubes to segment and higlight cube if selected and execute function if clicked 
        for (int i = 0; i < segments; i++)
        {
            var cubeRenderer = cubes[i].GetComponent<Renderer>();
            if (newIndex != i)
            {
                cubeRenderer.material.SetColor("_Color", Color.white);
            }
            else
            {
                if (ViveInput.GetPress(CCCHand, SelectionButton))
                {
                    cubeRenderer.material.SetColor("_Color", Color.red);
				}
				else if (ViveInput.GetPressUp(CCCHand, SelectionButton))
				{
					mover.ExecuteFunction(i);
                }
                else
                {
                    cubeRenderer.material.SetColor("_Color", Color.gray);
                }
            }
        }
    }    

    // transform analog stick position into polar coordinates for further use
     protected void PolarCoordinates(int nSegments, float x, float y)
     {
         if (x == 0 && y == 0)
         {
             newIndex = -1;
         }
         else
         {
             float segmentAngle = 360f / nSegments;
             angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg + segmentAngle/2;
             if (angle < 0)
             {
                 angle += 360;
             }
             newIndex = Mathf.FloorToInt(angle / segmentAngle);             
         }
     }
     

     // Position is bound to controller position, orientation faces the camera 
     protected virtual void SetPositionAndRotation() {}
}

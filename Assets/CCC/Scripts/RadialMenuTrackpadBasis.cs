using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.ColliderEvent;
using System.Collections;
using System.Collections.Generic;

public class RadialMenuTrackpadBasis : MonoBehaviour
{
    public GameObject TheCCC;
    public HandRole CCCHand = HandRole.LeftHand;
    public ControllerButton ActivationButton = ControllerButton.Trigger;
    public ControllerButton SelectionButton = ControllerButton.Grip;
    public ColliderButtonEventData.InputButton SelectButton = 
        ColliderButtonEventData.InputButton.PadOrStick;
    public bool Show = false;
    protected bool Colliders = true;
    protected GameObject m_Controller;
    protected float x_, y_, angle;
    public int newIndex;
    protected int segments = 4;
    protected GameObject[] cubes;
    protected GameObject m_ControllerCollider;
    
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
            if (Colliders == true)
            {
                m_ControllerCollider = GameObject.Find("Left");
            }
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
            if (Colliders == true)
            {
                m_ControllerCollider = GameObject.Find("Right");
            }
        }
        
        Logger.Debug("<<< ViuCCC.Start");
        SetPositionAndRotation();
        
        TheCCC.SetActive(Show);
    }
    
    protected void Update()
    {
        SetPositionAndRotation();
        Colliders = false;
        y_ = Input.GetAxis("Vertical");
        x_ = Input.GetAxis("Horizontal");
        PolarCoordinates(segments, x_, y_);
		GameObject kapsel = GameObject.Find("Kapsel");
		Mover mover = kapsel.GetComponent<Mover>();
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
   
    protected void OnEnable()
    {
        ViveInput.AddListenerEx(CCCHand,
            ActivationButton,
            ButtonEventType.Up,
            ToggleCCC);
    }
    
    protected void OnDisable()
    {
        ViveInput.RemoveListenerEx(CCCHand,
            ActivationButton,
            ButtonEventType.Up,
            ToggleCCC);
    }
    
    protected void ToggleCCC()
    {
        Logger.Debug(">>> ToggleCCC");
        Show = !Show;

        if (Show)
        {   
            TheCCC.SetActive(Show);
            SetPositionAndRotation();
            m_ControllerCollider.SetActive(false);
        }
        else
        {
            TheCCC.SetActive(Show);
            Logger.Debug("CCC Objekt wird ausgeblendet!");
            m_ControllerCollider.SetActive(true);
        }
        Logger.Debug("<<< ToggleCCC");
    }
    
    protected void FindTheCCC()
    {
        TheCCC = GameObject.Find(TheCCC.name);
        if (!TheCCC)
        {
            Logger.Fatal("CCC-Objekt wurde nicht gefunden!!");
            return;
        }
    }
    
    protected static readonly log4net.ILog Logger 
        = log4net.LogManager.GetLogger(typeof(ViuCCC));
    
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
     
     protected void SetPositionAndRotation()
     {
         TheCCC.transform.SetPositionAndRotation(
             m_Controller.transform.position, 
             Camera.main.transform.rotation);        
     }
}
